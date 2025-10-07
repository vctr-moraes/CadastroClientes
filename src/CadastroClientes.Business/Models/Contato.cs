using System.Diagnostics.CodeAnalysis;
using CadastroClientes.Core.DomainObjects;

namespace CadastroClientes.Business.Models;

[ExcludeFromCodeCoverage]
public class Contato : Entity
{
    protected Contato()
    {
    }

    public Contato(
        string descricaoContato,
        string nomeRepresentante,
        string emailRepresentante,
        string telefoneRepresentante,
        string emailComercial,
        string telefoneComercial,
        string cargo,
        Cliente cliente)
    {
        DescricaoContato = descricaoContato;
        NomeRepresentante = nomeRepresentante;
        TelefoneRepresentante = telefoneRepresentante;
        EmailRepresentante = emailRepresentante;
        TelefoneComercial = telefoneComercial;
        EmailComercial = emailComercial;
        Cargo = cargo;
        ClienteId = cliente.Id;
    }

    public string DescricaoContato { get; private set; }
    public string NomeRepresentante { get; private set; }
    public string EmailRepresentante { get; private set; }
    public string TelefoneRepresentante { get; private set; }
    public string EmailComercial { get; private set; }
    public string TelefoneComercial { get; private set; }
    public string Cargo { get; private set; }
    public Cliente Cliente { get; private set; }
    public Guid ClienteId { get; private set; }
}