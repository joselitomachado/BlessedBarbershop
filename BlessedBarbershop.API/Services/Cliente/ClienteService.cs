using BlessedBarbershop.API.DTOs.Cliente;
using BlessedBarbershop.API.Models;
using BlessedBarbershop.API.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BlessedBarbershop.API.Services.Cliente;

public class ClienteService : IClienteInterface
{
    private readonly BlessedBarbershopDbContext _barbershopDb;

    public ClienteService(BlessedBarbershopDbContext barbershopDb)
    {
        _barbershopDb = barbershopDb;
    }

    public async Task<ResponseModel<IEnumerable<ClienteModel>>> ObterTodosClientes()
    {
        ResponseModel<IEnumerable<ClienteModel>> response = new();

        try
        {
            var clientes = await _barbershopDb.Clientes.OrderByDescending(c => c.Pontos).ToListAsync();

            response.Data = clientes;
            return response;
        }
        catch (Exception ex)
        {
            response.Message = ex.Message;
            response.Status = false;
            return response;
        }
    }

    public async Task<ResponseModel<ClienteModel>> ObterClientePorNomeSobrenome(string nome, string sobrenome)
    {
        ResponseModel<ClienteModel> response = new();

        try
        {
            var cliente = await _barbershopDb.Clientes
                .Where(c => c.Nome == nome && c.Sobrenome == sobrenome)
                .FirstOrDefaultAsync();

            if (cliente == null)
            {
                response.Message = "Nenhum cliente encontrado.";
                return response;
            }

            response.Data = cliente;
            return response;
        }
        catch (Exception ex)
        {
            response.Message = ex.Message;
            response.Status = false;
            return response;
        }
    }

    public async Task<ResponseModel<ClienteModel>> ObterClientePorID(int id)
    {
        ResponseModel<ClienteModel> response = new();

        try
        {
            var cliente = await _barbershopDb.Clientes.FindAsync(id);

            if (cliente == null)
            {
                response.Message = "Nenhum cliente encontrado.";
                return response;
            }

            response.Data = cliente;
            return response;
        }
        catch (Exception ex)
        {
            response.Message = ex.Message;
            response.Status = false;
            return response;
        }
    }

    public async Task<ResponseModel<ClienteModel>> CadastrarCliente(ClienteDto clienteDto)
    {
        ResponseModel<ClienteModel> response = new();

        try
        {
            var numeroCadastrado = await _barbershopDb.Clientes.AnyAsync(c => c.DDD == clienteDto.DDD && c.NumeroCelular == clienteDto.NumeroCelular);
            var emailCadastrado = !string.IsNullOrEmpty(clienteDto.Email) && await _barbershopDb.Clientes.AnyAsync(c => c.Email == clienteDto.Email);

            if (numeroCadastrado)
            {
                response.Message = "Cliente com o mesmo DDD e número de celular já existe.";
                return response;
            }

            if(emailCadastrado)
            {
                response.Message = "Cliente com o mesmo email já existe.";
                return response;
            }

            var cliente = new ClienteModel()
            {
                Nome = clienteDto.Nome,
                Sobrenome = clienteDto.Sobrenome,
                Email = clienteDto.Email,
                DDD = clienteDto.DDD,
                NumeroCelular = clienteDto.NumeroCelular,
                DataCadastro = DateTime.Now
            };

            _barbershopDb.Clientes.Add(cliente);
            await _barbershopDb.SaveChangesAsync();

            response.Data = cliente;
            response.Message = "Cliente cadastrado com sucesso.";

            return response;
        }
        catch (Exception ex)
        {
            response.Message = ex.Message;
            response.Status = false;
            return response;
        }
    }

    public async Task<ResponseModel<ClienteModel>> AtualizarCliente(int id, ClienteDto clienteDto)
    {
        ResponseModel<ClienteModel> response = new();

        try
        {
            var cliente = await _barbershopDb.Clientes.FindAsync(id);

            if (cliente == null)
            {
                response.Message = "Nenhum cliente encontrado.";
                return response;
            }

            cliente.Nome = clienteDto.Nome;
            cliente.Sobrenome = clienteDto.Sobrenome;
            cliente.Email = clienteDto.Email;
            cliente.DDD = clienteDto.DDD;
            cliente.NumeroCelular = clienteDto.NumeroCelular;

            _barbershopDb.Clientes.Update(cliente);
            await _barbershopDb.SaveChangesAsync();

            response.Data = cliente;
            response.Message = "Cliente atualizado com sucesso.";

            return response;


        }
        catch (Exception ex)
        {
            response.Message = ex.Message;
            response.Status = false;
            return response;
        }
    }

    public async Task<ResponseModel<ClienteModel>> ExcluirCliente(int id)
    {
        ResponseModel<ClienteModel> response = new();

        try
        {
            var cliente = await _barbershopDb.Clientes.FindAsync(id);

            if (cliente == null)
            {
                response.Message = "Nenhum cliente encontrado.";
                return response;
            }

            _barbershopDb.Clientes.Remove(cliente);
            await _barbershopDb.SaveChangesAsync();

            response.Data = cliente;
            response.Message = "Cliente removido com sucesso.";

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
