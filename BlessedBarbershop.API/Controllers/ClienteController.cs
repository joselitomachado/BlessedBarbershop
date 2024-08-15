using BlessedBarbershop.API.DTOs.Cliente;
using BlessedBarbershop.API.Models;
using BlessedBarbershop.API.Services.Cliente;
using Microsoft.AspNetCore.Mvc;

namespace BlessedBarbershop.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClienteController : ControllerBase
{
    private readonly IClienteInterface _clienteInterface;

    public ClienteController(IClienteInterface clienteInterface)
    {
        _clienteInterface = clienteInterface;
    }

    [HttpGet]
    [Route("ObterTodosClientes")]
    public async Task<ActionResult<ResponseModel<IEnumerable<ClienteModel>>>> ObterTodosClientes()
    {
        var clientes = await _clienteInterface.ObterTodosClientes();

        return Ok(clientes);
    }

    [HttpGet]
    [Route("ObterClientePorNomeSobrenome")]
    public async Task<ActionResult<ResponseModel<ClienteModel>>> ObterClientePorNomeSobrenome(string nome, string sobrenome)
    {
        var cliente = await _clienteInterface.ObterClientePorNomeSobrenome(nome, sobrenome);

        return Ok(cliente);
    }

    [HttpGet]
    [Route("ObterClientePorID/{id}")]
    public async Task<ActionResult<ResponseModel<ClienteModel>>> ObterClientePorID([FromRoute] int id)
    {
        var cliente = await _clienteInterface.ObterClientePorID(id);

        return Ok(cliente);
    }

    [HttpPost]
    [Route("CadastrarCliente")]
    public async Task<ActionResult<ResponseModel<ClienteModel>>> CadastrarCliente([FromBody] ClienteDto clienteDto)
    {
        var cliente = await _clienteInterface.CadastrarCliente(clienteDto);

        return Ok(cliente);
    }

    [HttpPut]
    [Route("AtualizarCliente/{id}")]
    public async Task<ActionResult<ResponseModel<ClienteModel>>> AtualizarCliente([FromRoute] int id, [FromBody] ClienteDto clienteDto)
    {
        var cliente = await _clienteInterface.AtualizarCliente(id, clienteDto);

        return Ok(cliente);
    }

    [HttpDelete]
    [Route("ExcluirCliente/{id}")]
    public async Task<ActionResult<ResponseModel<ClienteModel>>> ExcluirCliente([FromRoute] int id)
    {
        var cliente = await _clienteInterface.ExcluirCliente(id);

        return Ok(cliente);
    }
}
