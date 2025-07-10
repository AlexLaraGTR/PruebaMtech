namespace MTech.OrdenesApi.Models
{
    public class Orden
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public Cliente? Cliente { get; set; }
        public DateTime FechaOrden { get; set; }
        public decimal Total { get; set; }

        public ICollection<DetalleOrden>? Detalles { get; set; }
    }
}
