using System.Diagnostics.CodeAnalysis;
using CadastroClientes.Business.Models;
using Microsoft.EntityFrameworkCore;

namespace CadastroClientes.Data.Context;

[ExcludeFromCodeCoverage]
public class CadastroClientesDbContext : DbContext
{
    public CadastroClientesDbContext(DbContextOptions<CadastroClientesDbContext> options)
    {
    }

    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Contato> Contatos { get; set; }
    public DbSet<Documento> Documentos { get; set; }
    public DbSet<Endereco> Enderecos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CadastroClientesDbContext).Assembly);

        foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
        {
            relationship.DeleteBehavior = DeleteBehavior.Cascade;
        }

        base.OnModelCreating(modelBuilder);
    }
}