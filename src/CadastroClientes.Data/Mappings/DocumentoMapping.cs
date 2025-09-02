using System.Diagnostics.CodeAnalysis;
using CadastroClientes.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CadastroClientes.Data.Mappings;

[ExcludeFromCodeCoverage]
public class DocumentoMapping : IEntityTypeConfiguration<Documento>
{
    public void Configure(EntityTypeBuilder<Documento> builder)
    {
        builder.HasKey(d => d.Id);

        builder
            .Property(d => d.Descricao)
            .IsRequired()
            .HasColumnType("varchar(500)");

        builder
            .Property(d => d.NomeArquivo)
            .IsRequired()
            .HasColumnType("varchar(200)");

        builder
            .Property(d => d.ChaveAcessoArmazenamento)
            .IsRequired()
            .HasColumnType("varchar(200)");

        builder
            .Property(d => d.DataHoraCriacao)
            .IsRequired();

        builder
            .HasOne(d => d.Cliente)
            .WithMany(c => c.Documentos)
            .HasForeignKey(d => d.ClienteId);

        builder.ToTable("Documentos");
    }
}