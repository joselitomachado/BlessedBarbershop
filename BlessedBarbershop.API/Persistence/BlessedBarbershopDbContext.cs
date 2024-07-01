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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProdutoServicoModel>()
            .HasIndex(p => p.Nome)
            .IsUnique();

        modelBuilder.Entity<ClienteModel>()
            .HasIndex(c => new { c.DDD, c.NumeroCelular })
            .IsUnique();

        modelBuilder.Entity<ClienteModel>()
            .HasIndex(c => c.Email)
            .IsUnique();
    }
}
