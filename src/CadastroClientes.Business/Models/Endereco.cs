using System.Diagnostics.CodeAnalysis;
using CadastroClientes.Core.DomainObjects;

namespace CadastroClientes.Business.Models;

[ExcludeFromCodeCoverage]
public class Endereco : Entity
{
    protected Endereco() { }

    public Endereco(
        string logradouro,
        string numero,
        string bairro,
        string cidade,
        string estado,
        string pais,
        string cep,
        Cliente cliente)
    {
        Logradouro = logradouro;
        Numero = numero;
        Bairro = bairro;
        Cidade = cidade;
        Estado = estado;
        Pais = pais;
        Cep = cep;
        Cliente = cliente;
        ClienteId = cliente.Id;
    }

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