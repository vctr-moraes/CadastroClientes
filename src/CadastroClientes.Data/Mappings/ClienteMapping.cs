using System.Diagnostics.CodeAnalysis;
using CadastroClientes.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CadastroClientes.Data.Mappings;

[ExcludeFromCodeCoverage]
public class ClienteMapping : IEntityTypeConfiguration<Cliente>
{
    public void Configure(EntityTypeBuilder<Cliente> builder)
    {
        builder.HasKey(c => c.Id);

        builder
            .Property(c => c.NomeFantasia)
            .IsRequired()
            .HasColumnType("varchar(100)");

        builder
            .Property(c => c.RazaoSocial)
            .IsRequired()
            .HasColumnType("varchar(100)");

        builder
            .Property(c => c.Cnpj)
            .IsRequired()
            .HasColumnType("varchar(50)");

        builder
            .Property(c => c.DataCadastro)
            .IsRequired();

        builder
            .HasOne(c => c.Endereco)
            .WithOne(e => e.Cliente)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasMany(c => c.Contatos)
            .WithOne(c => c.Cliente)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasMany(c => c.Documentos)
            .WithOne(d => d.Cliente)
            .OnDelete(DeleteBehavior.Restrict);

        builder.ToTable("Clientes");
    }
}