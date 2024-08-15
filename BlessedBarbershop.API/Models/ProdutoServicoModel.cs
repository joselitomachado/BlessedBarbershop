using BlessedBarbershop.API.Enums;

namespace BlessedBarbershop.API.Models;

public class ProdutoServicoModel
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public decimal Valor { get; set; }
    public Categoria Categoria { get; set; }
    public DateTime DataCadastro { get; set; }
}
