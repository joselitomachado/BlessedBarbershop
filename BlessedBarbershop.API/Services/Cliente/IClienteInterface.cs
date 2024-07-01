using BlessedBarbershop.API.DTOs.Cliente;
using BlessedBarbershop.API.Models;

namespace BlessedBarbershop.API.Services.Cliente;

public interface IClienteInterface
{
    Task<ResponseModel<IEnumerable<ClienteModel>>> ObterTodosClientes();
    Task<ResponseModel<ClienteModel>> ObterClientePorNomeSobrenome(string nome, string sobrenome);
    Task<ResponseModel<ClienteModel>> ObterClientePorID(int id);
    Task<ResponseModel<ClienteModel>> CadastrarCliente(ClienteDto clienteDto);
    Task<ResponseModel<ClienteModel>> AtualizarCliente(int id, ClienteDto clienteDto);
    Task<ResponseModel<ClienteModel>> ExcluirCliente(int id);
}
