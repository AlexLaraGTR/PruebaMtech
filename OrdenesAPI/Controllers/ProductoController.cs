using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrdenesAPI.Data;
using OrdenesAPI.Models;

namespace OrdenesAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductoController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/producto
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Producto>>> GetProductos()
        {
            return await _context.Productos.ToListAsync();
        }

        // POST: api/producto
        [HttpPost]
        public async Task<ActionResult<Producto>> PostProducto(Producto producto)
        {
            if (producto.Precio < 0 || producto.Stock < 0)
                return BadRequest("El precio y el stock deben ser valores positivos.");

            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProductos), new { id = producto.Id }, producto);
        }

        [HttpGet("sin-stock")]
        public async Task<IActionResult> ProductosSinStock()
        {
            var sinStock = await _context.Productos
                .Where(p => p.Stock == 0)
                .ToListAsync();

            return Ok(sinStock);
        }
    }
}
