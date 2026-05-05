namespace Lab8_BenaventeRojas.DTOs;

public class DetallePedidoDto
{
    public int Id { get; set; }
    public int ProductoId { get; set; }
    public string ProductoNombre { get; set; } = string.Empty;
    public int Cantidad { get; set; }
    public decimal PrecioUnitario { get; set; }
    public decimal Subtotal { get; set; }
}

public class PedidoDto
{
    public int Id { get; set; }
    public DateTime Fecha { get; set; }
    public int ClienteId { get; set; }
    public string ClienteNombre { get; set; } = string.Empty;
    public string ClienteEmail { get; set; } = string.Empty;
    public decimal Total { get; set; }
    public IReadOnlyList<DetallePedidoDto> Detalles { get; set; } = Array.Empty<DetallePedidoDto>();
}

public class CreateDetallePedidoDto
{
    public int ProductoId { get; set; }
    public int Cantidad { get; set; }
}

public class CreatePedidoDto
{
    public int ClienteId { get; set; }
    public DateTime? Fecha { get; set; }
    public List<CreateDetallePedidoDto> Detalles { get; set; } = new();
}

public class UpdatePedidoDto
{
    public int ClienteId { get; set; }
    public DateTime Fecha { get; set; }
    public List<CreateDetallePedidoDto> Detalles { get; set; } = new();
}