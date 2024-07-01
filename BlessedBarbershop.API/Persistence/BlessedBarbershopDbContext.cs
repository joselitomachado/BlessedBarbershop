using BlessedBarbershop.API.Models;
using Microsoft.EntityFrameworkCore;

namespace BlessedBarbershop.API.Persistence;

public class BlessedBarbershopDbContext : DbContext
{
    public BlessedBarbershopDbContext(DbContextOptions<BlessedBarbershopDbContext> options) : base(options)
    {
    }

    public DbSet<ProdutoServicoModel> ProdutosServicos { get; set; }
    public DbSet<ClienteModel> Clientes { get; set; }
    public DbSet<VendaModel> Vendas { get; set; }
}
