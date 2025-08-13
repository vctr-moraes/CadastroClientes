using System.Diagnostics.CodeAnalysis;

namespace CadastroClientes.Business.Models;

[ExcludeFromCodeCoverage]
public class Endereco
{
    public string Logradouro { get; private set; }
    public string Numero { get; private set; }
    public string Bairro { get; private set; }
    public string Cidade { get; private set; }
    public string Estado { get; private set; }
    public string Pais { get; private set; }
    public string Cep { get; private set; }
    public Cliente Cliente { get; private set; }
    public Guid ClienteId { get; private set; }
}