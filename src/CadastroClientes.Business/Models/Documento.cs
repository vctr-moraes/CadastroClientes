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
        TipoDocumento tipoDocumento,
        Cliente cliente)
    {
        Descricao = descricao;
        DataHoraCriacao = DateTime.Now;
        TipoDocumento = tipoDocumento;
        Cliente = cliente;
        ClienteId = cliente.Id;
    }

    public string Descricao { get; private set; }
    public DateTime DataHoraCriacao { get; private set; }
    public TipoDocumento TipoDocumento { get; private set; }
    public Cliente Cliente { get; private set; }
    public Guid ClienteId { get; private set; }
}