using System.Diagnostics.CodeAnalysis;
using CadastroClientes.Core.DomainObjects;

namespace CadastroClientes.Business.Models;

[ExcludeFromCodeCoverage]
public class Documento : Entity
{
    protected Documento()
    {
    }

    public Documento(
        string descricao,
        string nomeArquivo,
        TipoDocumento tipoDocumento,
        Cliente cliente)
    {
        Descricao = descricao;
        NomeArquivo = nomeArquivo;
        ChaveAcessoArmazenamento = string.Empty;
        DataHoraCriacao = DateTime.Now;
        TipoDocumento = tipoDocumento;
        ClienteId = cliente.Id;
    }

    public string Descricao { get; private set; }
    public string NomeArquivo { get; private set; }
    public string ChaveAcessoArmazenamento { get; private set; }
    public DateTime DataHoraCriacao { get; private set; }
    public TipoDocumento TipoDocumento { get; private set; }
    public Cliente Cliente { get; private set; }
    public Guid ClienteId { get; private set; }
}