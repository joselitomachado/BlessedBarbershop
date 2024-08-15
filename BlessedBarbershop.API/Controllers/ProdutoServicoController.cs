using BlessedBarbershop.API.DTOs.ProdutoServico;
using BlessedBarbershop.API.Models;
using BlessedBarbershop.API.Services.ProdutoServico;
using Microsoft.AspNetCore.Mvc;

namespace BlessedBarbershop.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProdutoServicoController : ControllerBase
{
    private readonly IProdutoServicoInterface _produtoServicoInterface;

    public ProdutoServicoController(IProdutoServicoInterface produtoServicoInterface)
    {
        _produtoServicoInterface = produtoServicoInterface;
    }

    [HttpGet]
    [Route("ObterTodosProdutosServicos")]
    public async Task<ActionResult<ResponseModel<IEnumerable<ProdutoServicoModel>>>> ObterTodosProdutosServicos()
    {
        var produtosServicos = await _produtoServicoInterface.ObterTodosProdutosServicos();

        return Ok(produtosServicos);
    }

    [HttpGet]
    [Route("ObterProdutoServicoPorNome/{nome}")]
    public async Task<ActionResult<ResponseModel<ProdutoServicoModel>>> ObterProdutoServicoPorNome(string nome)
    {
        var produtoServico = await _produtoServicoInterface.ObterProdutoServicoPorNome(nome);

        return Ok(produtoServico);
    }

    [HttpGet]
    [Route("ObterProdutoServicoPorId/{id}")]
    public async Task<ActionResult<ResponseModel<ProdutoServicoModel>>> ObterProdutoServicoPorId([FromRoute] int id)
    {
        var produtoServico = await _produtoServicoInterface.ObterProdutoServicoPorId(id);

        return Ok(produtoServico);
    }

    [HttpPost]
    [Route("CadastrarProdutoServico")]
    public async Task<ActionResult<ResponseModel<ProdutoServicoModel>>> CadastrarProdutoServico([FromBody] ProdutoServicoDto produtoServicoDto)
    {
        var produtoServico = await _produtoServicoInterface.CadastrarProdutoServico(produtoServicoDto);

        return Ok(produtoServico);
    }

    [HttpPut]
    [Route("AtualizarProdutoServico/{id}")]
    public async Task<ActionResult<ResponseModel<ProdutoServicoModel>>> AtualizarProdutoServico([FromRoute] int id, [FromBody] ProdutoServicoDto produtoServicoDto)
    {
        var produtoServico = await _produtoServicoInterface.AtualizarProdutoServico(id, produtoServicoDto);

        return Ok(produtoServico);
    }

    [HttpDelete]
    [Route("ExcluirProdutoServico/{id}")]
    public async Task<ActionResult<ResponseModel<ProdutoServicoModel>>> ExcluirProdutoServico([FromRoute] int id)
    {
        var produtoServico = await _produtoServicoInterface.ExcluirProdutoServico(id);

        return Ok(produtoServico);
    }
}
