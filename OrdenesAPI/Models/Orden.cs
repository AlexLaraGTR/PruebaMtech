namespace OrdenesAPI.Models;

public class Orden
{
    public int Id { get; set; }
    public int ClienteId { get; set; }
    public Cliente? Cliente { get; set; }
    public DateTime FechaOrden { get; set; }
    public decimal Total { get; set; }

    public List<DetalleOrden> Detalles { get; set; } = new();
}
