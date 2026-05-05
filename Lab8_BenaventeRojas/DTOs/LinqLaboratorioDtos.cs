namespace Lab8_BenaventeRojas.DTOs;

/// <summary>Ejercicio 3 y 10: detalle con nombre de producto y cantidad.</summary>
public class DetalleOrdenProductoDto
{
    public string ProductoNombre { get; set; } = string.Empty;
    public int Cantidad { get; set; }
}

/// <summary>Ejercicio 10: pedido con líneas de detalle.</summary>
public class PedidoConDetallesNombreCantidadDto
{
    public int PedidoId { get; set; }
    public DateTime Fecha { get; set; }
    public int ClienteId { get; set; }
    public IReadOnlyList<DetalleOrdenProductoDto> Detalles { get; set; } = Array.Empty<DetalleOrdenProductoDto>();
}

/// <summary>Ejercicio 9: cliente con mayor número de pedidos.</summary>
public class ClienteMayorPedidosDto
{
    public int ClienteId { get; set; }
    public string ClienteNombre { get; set; } = string.Empty;
    public int CantidadPedidos { get; set; }
}