using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrdenesAPI.Data;
using OrdenesAPI.Models;

namespace OrdenesAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ClienteController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/cliente
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes()
        {
            return await _context.Clientes.ToListAsync();
        }
        // POST: api/cliente
        [HttpPost]
        public async Task<ActionResult<Cliente>> PostCliente(Cliente cliente)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Validar email básico (puedes mejorar esto después)
            if (string.IsNullOrWhiteSpace(cliente.Email) || !cliente.Email.Contains("@"))
                return BadRequest("El email no tiene un formato válido.");

            cliente.FechaRegistro = DateTime.UtcNow;

            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetClientes), new { id = cliente.Id }, cliente);
        }
        [HttpGet("top-gastos")]
        public async Task<IActionResult> TopClientes()
        {
            var seisMesesAtras = DateTime.UtcNow.AddMonths(-6);

            var topClientes = await _context.Clientes
                .Select(c => new
                {
                    Cliente = c.Nombre,
                    TotalGastado = c.Ordenes
                        .Where(o => o.FechaOrden >= seisMesesAtras)
                        .Sum(o => (decimal?)o.Total) ?? 0
                })
                .ToListAsync(); // Pull data into memory first

            var orderedTop = topClientes
                .OrderByDescending(c => c.TotalGastado)
                .Take(3);

            return Ok(orderedTop);
        }
    }
}
