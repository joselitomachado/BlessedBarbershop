namespace BlessedBarbershop.API.Models;

public class VendaModel
{
    public int Id { get; set; }
    public int ClienteId { get; set; }
    public ClienteModel? Cliente { get; set; }
    public int ProdutoServicoId { get; set; }
    public ProdutoServicoModel? ProdutoServico { get; set; }
    public DateTime DataCadastro { get; set; }
}
