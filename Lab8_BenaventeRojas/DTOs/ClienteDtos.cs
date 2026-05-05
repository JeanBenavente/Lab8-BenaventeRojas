namespace Lab8_BenaventeRojas.DTOs;

public class ClienteDto
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}

public class CreateClienteDto
{
    public string Nombre { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}

public class UpdateClienteDto
{
    public string Nombre { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}