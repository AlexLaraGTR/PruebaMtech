using Microsoft.EntityFrameworkCore;
using OrdenesAPI.Models;

namespace OrdenesAPI.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    public DbSet<Cliente> Clientes => Set<Cliente>();
    public DbSet<Producto> Productos => Set<Producto>();
    public DbSet<Orden> Ordenes => Set<Orden>();
    public DbSet<DetalleOrden> DetallesOrden => Set<DetalleOrden>();
}
