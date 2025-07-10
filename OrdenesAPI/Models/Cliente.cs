namespace OrdenesAPI.Models;

public class Cliente
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public DateTime FechaRegistro { get; set; }
    public List<Orden> Ordenes { get; set; } = new();
}
