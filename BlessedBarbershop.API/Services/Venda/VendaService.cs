using BlessedBarbershop.API.DTOs.Venda;
using BlessedBarbershop.API.Models;
using BlessedBarbershop.API.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BlessedBarbershop.API.Services.Venda;

public class VendaService : IVendaInterface
{
    private readonly BlessedBarbershopDbContext _barbershopDb;

    public VendaService(BlessedBarbershopDbContext barbershopDb)
    {
        _barbershopDb = barbershopDb;
    }

    public async Task<ResponseModel<IEnumerable<VendaModel>>> ObterTodasVendas()
    {
        ResponseModel<IEnumerable<VendaModel>> response = new();

        try
        {
            var vendas = await _barbershopDb.Vendas
                .Include(x => x.Cliente)
                .Include(x => x.ProdutoServico)
                .ToListAsync();

            response.Data = vendas;
            return response;
        }
        catch (Exception ex)
        {
            response.Message = ex.Message;
            response.Status = false;
            return response;
        }
    }

    public async Task<ResponseModel<IEnumerable<VendaModel>>> ObterVendaPorData(DateTime dataCadastro)
    {
        ResponseModel<IEnumerable<VendaModel>> response = new();

        try
        {
            var venda = await _barbershopDb.Vendas
                .Where(v => v.DataCadastro.Date == dataCadastro.Date)
                .Include(x => x.Cliente)
                .Include(x => x.ProdutoServico)
                .ToListAsync();

            if (venda == null)
            {
                response.Message = "Nenhuma venda encontrado.";
                return response;
            }

            response.Data = venda;
            return response;
        }
        catch (Exception ex)
        {
            response.Message = ex.Message;
            response.Status = false;
            return response;
        }
    }

    public async Task<ResponseModel<IEnumerable<VendaModel>>> ObterVendaPorCliente(int clienteId)
    {
        ResponseModel<IEnumerable<VendaModel>> response = new();

        try
        {
            var vendas = await _barbershopDb.Vendas
                .Where(v => v.ClienteId == clienteId)
                .Include(v => v.Cliente)
                .Include(v => v.ProdutoServico)
                .ToListAsync();

            if (vendas == null)
            {
                response.Message = "Nenhuma venda encontrado.";
                return response;
            }

            response.Data = vendas;
            return response;
        }
        catch (Exception ex)
        {
            response.Message = ex.Message;
            response.Status = false;
            return response;
        }
    }
    public async Task<ResponseModel<VendaModel>> CadastrarVenda(VendaDto vendaDto)
    {
        ResponseModel<VendaModel> response = new();

        try
        {
            var cliente = await _barbershopDb.Clientes.FindAsync(vendaDto.ClienteId);
            var produtoServico = await _barbershopDb.ProdutosServicos.FindAsync(vendaDto.ProdutoServicoId);

            if (cliente == null || produtoServico == null)
            {
                response.Message = "Cliente ou produto/serviço não encontrado.";
                return response;
            }

            var venda = new VendaModel()
            {
                ClienteId = vendaDto.ClienteId,
                ProdutoServicoId = vendaDto.ProdutoServicoId,
                DataCadastro = DateTime.Now
            };

            _barbershopDb.Vendas.Add(venda);
            cliente.Pontos += (int)produtoServico.Valor;
            await _barbershopDb.SaveChangesAsync();

            response.Data = venda;
            response.Message = "Venda cadastrada com sucesso.";

            return response;
        }
        catch (Exception ex)
        {
            response.Message = ex.Message;
            response.Status = false;
            return response;
        }
    }

    public async Task<ResponseModel<VendaModel>> ExcluirVenda(int id)
    {
        ResponseModel<VendaModel> response = new();

        try
        {
            var venda = await _barbershopDb.Vendas.FindAsync(id);

            if (venda == null)
            {
                response.Message = "Nenhuma venda encontrado";
                return response;
            }

            var cliente = await _barbershopDb.Clientes.FindAsync(venda.ClienteId);
            var produtoServico = await _barbershopDb.ProdutosServicos.FindAsync(venda.ProdutoServicoId);

            if (cliente != null && produtoServico != null)
            {
                cliente.Pontos -= (int)produtoServico.Valor;
            }

            _barbershopDb.Vendas.Remove(venda);
            await _barbershopDb.SaveChangesAsync();

            response.Data = venda;
            response.Message = "Venda removida com sucesso.";

            return response;
        }
        catch (Exception ex)
        {
            response.Message = ex.Message;
            response.Status = false;
            return response;
        }
    }
}
