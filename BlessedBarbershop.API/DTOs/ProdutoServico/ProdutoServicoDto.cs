using System.ComponentModel.DataAnnotations;

namespace BlessedBarbershop.API.DTOs.ProdutoServico;

public class ProdutoServicoDto
{
    [Required]
    public string Nome { get; set; } = string.Empty;
    [Required]
    public decimal Valor { get; set; }
    [Required]
    public string Categoria { get; set; } = string.Empty;
}
