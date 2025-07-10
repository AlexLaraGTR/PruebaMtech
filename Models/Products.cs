namespace MTech.OrdenesApi.Models
{
    public class Products
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }

        public ICollection<DetalleOrden>? DetallesOrden { get; set; }
    }
}