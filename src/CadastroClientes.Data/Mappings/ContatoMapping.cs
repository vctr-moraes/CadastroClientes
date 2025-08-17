using System.Diagnostics.CodeAnalysis;
using CadastroClientes.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CadastroClientes.Data.Mappings;

[ExcludeFromCodeCoverage]
public class ContatoMapping : IEntityTypeConfiguration<Contato>
{
    public void Configure(EntityTypeBuilder<Contato> builder)
    {
        builder.HasKey(c => c.Id);

        builder
            .Property(c => c.DescricaoContato)
            .IsRequired()
            .HasColumnType("varchar(300)");

        builder
            .Property(c => c.NomeRepresentante)
            .IsRequired()
            .HasColumnType("varchar(100)");

        builder
            .Property(c => c.EmailRepresentante)
            .IsRequired()
            .HasColumnType("varchar(100)");

        builder
            .Property(c => c.TelefoneRepresentante)
            .IsRequired()
            .HasColumnType("varchar(20)");

        builder
            .Property(c => c.EmailComercial)
            .IsRequired()
            .HasColumnType("varchar(100)");

        builder
            .Property(c => c.TelefoneComercial)
            .IsRequired()
            .HasColumnType("varchar(20)");

        builder
            .Property(c => c.Cargo)
            .IsRequired()
            .HasColumnType("varchar(100)");

        builder
            .HasOne(c => c.Cliente)
            .WithMany(c => c.Contatos)
            .HasForeignKey(c => c.ClienteId);

        builder.ToTable("Contatos");
    }
}