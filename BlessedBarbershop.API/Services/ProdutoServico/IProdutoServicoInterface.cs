using BlessedBarbershop.API.DTOs.ProdutoServico;
using BlessedBarbershop.API.Models;

namespace BlessedBarbershop.API.Services.ProdutoServico;

public interface IProdutoServicoInterface
{
    Task<ResponseModel<IEnumerable<ProdutoServicoModel>>> ObterTodosProdutosServicos();
    Task<ResponseModel<ProdutoServicoModel>> ObterProdutoServicoPorNome(string nome);
    Task<ResponseModel<ProdutoServicoModel>> ObterProdutoServicoPorId(int id);
    Task<ResponseModel<ProdutoServicoModel>> CadastrarProdutoServico(ProdutoServicoDto produtoServicoDto);
    Task<ResponseModel<ProdutoServicoModel>> AtualizarProdutoServico(int id, ProdutoServicoDto produtoServicoDto);
    Task<ResponseModel<ProdutoServicoModel>> ExcluirProdutoServico(int id);
}