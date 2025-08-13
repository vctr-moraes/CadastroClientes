using System.Diagnostics.CodeAnalysis;

namespace CadastroClientes.Business.Models;

[ExcludeFromCodeCoverage]
public class Contato
{
    public string DescricaoContato { get; private set; }
    public string NomeRepresentante { get; private set; }
    public string EmailRepresentante { get; private set; }
    public string TelefoneRepresentante { get; private set; }
    public string TelefoneComercial { get; private set; }
    public string EmailComercial { get; private set; }
    public string Cargo { get; private set; }
    public Cliente Cliente { get; private set; }
    public Guid ClienteId { get; private set; }
}