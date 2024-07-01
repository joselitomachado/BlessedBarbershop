using BlessedBarbershop.API.DTOs.Venda;
using BlessedBarbershop.API.Models;

namespace BlessedBarbershop.API.Services.Venda;

public interface IVendaInterface
{
    Task<ResponseModel<IEnumerable<VendaModel>>> ObterTodasVendas();
    Task<ResponseModel<IEnumerable<VendaModel>>> ObterVendaPorCliente(int clienteId);
    Task<ResponseModel<IEnumerable<VendaModel>>> ObterVendaPorData(DateTime dataCadastro);
    Task<ResponseModel<VendaModel>> CadastrarVenda(VendaDto vendaDto);
    Task<ResponseModel<VendaModel>> ExcluirVenda(int id);
}
