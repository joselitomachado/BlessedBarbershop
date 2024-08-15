using BlessedBarbershop.API.DTOs.Venda;
using BlessedBarbershop.API.Models;
using BlessedBarbershop.API.Services.Venda;
using Microsoft.AspNetCore.Mvc;

namespace BlessedBarbershop.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VendaController : ControllerBase
{
    private readonly IVendaInterface _vendaInterface;

    public VendaController(IVendaInterface vendaInterface)
    {
        _vendaInterface = vendaInterface;
    }

    [HttpGet]
    [Route("ObterTodasVendas")]
    public async Task<ActionResult<ResponseModel<IEnumerable<VendaModel>>>> ObterTodasVendas()
    {
        var vendas = await _vendaInterface.ObterTodasVendas();

        return Ok(vendas);
    }

    [HttpGet]
    [Route("ObterVendaPorData/{dataCadastro}")]
    public async Task<ActionResult<ResponseModel<IEnumerable<VendaModel>>>> ObterVendaPorData([FromRoute] DateTime dataCadastro)
    {
        var venda = await _vendaInterface.ObterVendaPorData(dataCadastro);

        return Ok(venda);
    }

    [HttpGet]
    [Route("ObterVendaPorCliente/{clienteId}")]
    public async Task<ActionResult<ResponseModel<IEnumerable<VendaModel>>>> ObterVendaPorCliente([FromRoute] int clienteId)
    {
        var venda = await _vendaInterface.ObterVendaPorCliente(clienteId);

        return Ok(venda);
    }

    [HttpPost]
    [Route("CadastrarVenda")]
    public async Task<ActionResult<ResponseModel<VendaModel>>> CadastrarVenda([FromBody] VendaDto vendaDto)
    {
        var venda = await _vendaInterface.CadastrarVenda(vendaDto);

        return Ok(venda);
    }

    [HttpDelete]
    [Route("ExcluirVenda/{id}")]
    public async Task<ActionResult<ResponseModel<VendaModel>>> ExcluirVenda([FromRoute] int id)
    {
        var venda = await _vendaInterface.ExcluirVenda(id);

        return Ok(venda);
    }
}
