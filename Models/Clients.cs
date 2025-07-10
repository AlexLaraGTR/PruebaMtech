namespace MTech.OrdenesApi.Models
{
    public class Clients
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public DateTime FechaRegistro { get; set; }

        public ICollection<Orden>? Ordenes { get; set; }
    }
}
