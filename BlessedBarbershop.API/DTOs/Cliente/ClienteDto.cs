using System.ComponentModel.DataAnnotations;

namespace BlessedBarbershop.API.DTOs.Cliente;

public class ClienteDto
{
    [Required]
    public string Nome { get; set; } = string.Empty;
    [Required]
    public string Sobrenome { get; set; } = string.Empty;
    public string? Email { get; set; } = string.Empty;
    [Required]
    public string DDD { get; set; } = string.Empty;
    [Required]
    public string NumeroCelular { get; set; } = string.Empty;
}
