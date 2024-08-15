using BlessedBarbershop.API.DTOs.ProdutoServico;
using BlessedBarbershop.API.Models;
using BlessedBarbershop.API.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BlessedBarbershop.API.Services.ProdutoServico;

public class ProdutoServicoService : IProdutoServicoInterface
{
    private readonly BlessedBarbershopDbContext _barbershopDb;

    public ProdutoServicoService(BlessedBarbershopDbContext barbershopDb)
    {
        _barbershopDb = barbershopDb;
    }

    public async Task<ResponseModel<IEnumerable<ProdutoServicoModel>>> ObterTodosProdutosServicos()
    {
        ResponseModel<IEnumerable<ProdutoServicoModel>> response = new();

        try
        {
            var produtosServicos = await _barbershopDb.ProdutosServicos.ToListAsync();

            response.Data = produtosServicos;

            return response;
        }
        catch (Exception ex)
        {
            response.Message = ex.Message;
            return response;
        }
    }

    public async Task<ResponseModel<ProdutoServicoModel>> ObterProdutoServicoPorNome(string nome)
    {
        ResponseModel<ProdutoServicoModel> response = new();

        try
        {
            var produtoServico = await _barbershopDb.ProdutosServicos
                .Where(p => p.Nome.Equals(nome, StringComparison.CurrentCultureIgnoreCase))
                .FirstOrDefaultAsync();

            if (produtoServico == null)
            {
                response.Message = "Produto ou Serviço não encontrado.";
                return response;
            }

            response.Data = produtoServico;

            return response;
        }
        catch (Exception ex)
        {
            response.Message = ex.Message;
            return response;
        }
    }

    public async Task<ResponseModel<ProdutoServicoModel>> ObterProdutoServicoPorId(int id)
    {
        ResponseModel<ProdutoServicoModel> response = new();

        try
        {
            var produtoServico = await _barbershopDb.ProdutosServicos.FirstOrDefaultAsync(ps => ps.Id == id);

            if (produtoServico == null)
            {
                response.Message = "Produto ou Serviço não encontrado.";
                return response;
            }

            response.Data = produtoServico;

            return response;
        }
        catch (Exception ex)
        {
            response.Message = ex.Message;
            return response;
        }
    }

    public async Task<ResponseModel<ProdutoServicoModel>> CadastrarProdutoServico(ProdutoServicoDto produtoServicoDto)
    {
        ResponseModel<ProdutoServicoModel> response = new();

        try
        {
            if (await _barbershopDb.ProdutosServicos.AnyAsync(p => p.Nome.Equals(produtoServicoDto.Nome, StringComparison.CurrentCultureIgnoreCase)))
            {
                response.Message = "Produto ou Serviço já existe com este nome.";
                return response;
            }

            var produtoServico = new ProdutoServicoModel()
            {
                Nome = produtoServicoDto.Nome,
                Valor = produtoServicoDto.Valor,
                Categoria = produtoServicoDto.Categoria,
                DataCadastro = DateTime.Now
            };

            _barbershopDb.ProdutosServicos.Add(produtoServico);
            await _barbershopDb.SaveChangesAsync();

            response.Data = produtoServico;
            response.Message = "Produto ou Serviço cadastrado com sucesso.";

            return response;
        }
        catch (Exception ex)
        {
            response.Message = ex.Message;
            return response;
        }
    }

    public async Task<ResponseModel<ProdutoServicoModel>> AtualizarProdutoServico(int id, ProdutoServicoDto produtoServicoDto)
    {
        ResponseModel<ProdutoServicoModel> response = new();

        try
        {
            var produtoServico = await _barbershopDb.ProdutosServicos.FirstOrDefaultAsync(ps => ps.Id == id);

            if (produtoServico == null)
            {
                response.Message = "Produto ou Serviço não encontrado.";
                return response;
            }

            produtoServico.Nome = produtoServicoDto.Nome;
            produtoServico.Valor = produtoServicoDto.Valor;
            produtoServico.Categoria = produtoServicoDto.Categoria;

            _barbershopDb.ProdutosServicos.Update(produtoServico);
            await _barbershopDb.SaveChangesAsync();

            response.Data = produtoServico;
            response.Message = "Produto ou Serviço atualizado com sucesso.";

            return response;
        }
        catch (Exception ex)
        {
            response.Message = ex.Message;
            return response;
        }
    }

    public async Task<ResponseModel<ProdutoServicoModel>> ExcluirProdutoServico(int id)
    {
        ResponseModel<ProdutoServicoModel> response = new();

        try
        {
            var produtoServico = await _barbershopDb.ProdutosServicos.FirstOrDefaultAsync(ps => ps.Id == id);

            if (produtoServico == null)
            {
                response.Message = "Produto ou Serviço não encontrado.";
                return response;
            }

            _barbershopDb.ProdutosServicos.Remove(produtoServico);
            await _barbershopDb.SaveChangesAsync();

            response.Message = "Produto ou Serviço removido com sucesso.";

            return response;
        }
        catch (Exception ex)
        {
            response.Message = ex.Message;
            return response;
        }
    }
}