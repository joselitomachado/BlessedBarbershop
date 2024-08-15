using System.ComponentModel.DataAnnotations;

namespace BlessedBarbershop.API.DTOs.Venda;

public class VendaDto
{
    [Required]
    public int ClienteId { get; set; }
    [Required]
    public int ProdutoServicoId { get; set; }
}
