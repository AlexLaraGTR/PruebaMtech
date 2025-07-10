namespace OrdenesAPI.Models;

public class OrdenRequest
{
    public int ClienteId { get; set; }
    public List<OrdenItemRequest> Productos { get; set; } = new();
}

public class OrdenItemRequest
{
    public int ProductoId { get; set; }
    public int Cantidad { get; set; }
}
