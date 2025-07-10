using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrdenesAPI.Data;
using OrdenesAPI.Models;

namespace OrdenesAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdenController : ControllerBase
    {
        private readonly AppDbContext _context;

        public OrdenController(AppDbContext context)
        {
            _context = context;
        }

        // POST: api/orden
        [HttpPost]
        public async Task<IActionResult> CrearOrden([FromBody] OrdenRequest request)
        {
            // Validar cliente
            var cliente = await _context.Clientes.FindAsync(request.ClienteId);
            if (cliente == null)
                return NotFound("Cliente no encontrado.");

            if (request.Productos == null || request.Productos.Count == 0)
                return BadRequest("La orden debe tener al menos un producto.");

            // Validar productos y stock
            var productosIds = request.Productos.Select(p => p.ProductoId).ToList();
            var productosBD = await _context.Productos
                                            .Where(p => productosIds.Contains(p.Id))
                                            .ToListAsync();

            if (productosBD.Count != productosIds.Count)
                return NotFound("Uno o más productos no existen.");

            foreach (var item in request.Productos)
            {
                if (item.Cantidad <= 0)
                    return BadRequest("La cantidad de productos debe ser mayor a cero.");

                var producto = productosBD.First(p => p.Id == item.ProductoId);
                if (producto.Stock < item.Cantidad)
                    return BadRequest($"Stock insuficiente para el producto {producto.Nombre}.");
            }

            // Crear orden
            var nuevaOrden = new Orden
            {
                ClienteId = request.ClienteId,
                FechaOrden = DateTime.UtcNow,
                Total = 0
            };

            _context.Ordenes.Add(nuevaOrden);
            await _context.SaveChangesAsync(); // Guardar para obtener el Id

            decimal total = 0;

            foreach (var item in request.Productos)
            {
                var producto = productosBD.First(p => p.Id == item.ProductoId);

                var detalle = new DetalleOrden
                {
                    OrdenId = nuevaOrden.Id,
                    ProductoId = producto.Id,
                    Cantidad = item.Cantidad,
                    PrecioUnitario = producto.Precio
                };

                total += producto.Precio * item.Cantidad;
                producto.Stock -= item.Cantidad;

                _context.DetallesOrden.Add(detalle);
            }

            nuevaOrden.Total = total;
            await _context.SaveChangesAsync();

            return Ok(new
            {
                OrdenId = nuevaOrden.Id,
                Total = nuevaOrden.Total,
                Fecha = nuevaOrden.FechaOrden
            });
        }
        // GET: api/orden
        [HttpGet]
        public async Task<IActionResult> ListarOrdenes()
        {
            var ordenes = await _context.Ordenes
                .Include(o => o.Cliente)
                .Include(o => o.Detalles)
                .ThenInclude(d => d.Producto)
                .Select(static o => new
                {
                    OrdenId = o.Id,
                    Cliente = o.Cliente.Nombre,
                    Total = o.Total,
                    ProductosDistintos = o.Detalles.Count,
                    Fecha = o.FechaOrden
                })
                .ToListAsync();

            return Ok(ordenes);
        }
    }
}
