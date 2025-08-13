using System.Diagnostics.CodeAnalysis;

namespace CadastroClientes.Business.Models;

[ExcludeFromCodeCoverage]
public class Documento
{
    public string Descricao { get; private set; }
    public DateTime DataHoraCriacao { get; private set; }
    public TipoDocumento TipoDocumento { get; private set; }
    public Cliente Cliente { get; private set; }
    public Guid ClienteId { get; private set; }
}