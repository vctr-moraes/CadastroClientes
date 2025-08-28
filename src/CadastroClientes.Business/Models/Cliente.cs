using System.Diagnostics.CodeAnalysis;
using CadastroClientes.Core.DomainObjects;

namespace CadastroClientes.Business.Models;

[ExcludeFromCodeCoverage]
public class Cliente : Entity
{
    private readonly List<Contato> _contatos;
    private readonly List<Documento> _documentos;

    protected Cliente()
    {
        _contatos = new List<Contato>();
        _documentos = new List<Documento>();
    }

    public Cliente(
        string nomeFantasia,
        string razaoSocial,
        string cnpj)
    {
        NomeFantasia = nomeFantasia;
        RazaoSocial = razaoSocial;
        Cnpj = cnpj;
        DataCadastro = DateTime.Now.Date;
        _contatos = new List<Contato>();
    }

    public string NomeFantasia { get; private set; }
    public string RazaoSocial { get; private set; }
    public string Cnpj { get; private set; }
    public DateTime DataCadastro { get; private set; }
    public Endereco Endereco { get; private set; }

    public IReadOnlyCollection<Contato> Contatos => _contatos;

    public IReadOnlyCollection<Documento> Documentos => _documentos;

    public void AtualizarCliente(
        string nomeFantasia,
        string razaoSocial,
        string cnpj)
    {
        NomeFantasia = nomeFantasia;
        RazaoSocial = razaoSocial;
        Cnpj = cnpj;
    }

    public void AdicionarContato(Contato contato)
    {
        _contatos.Add(contato);
    }

    public void RemoverContato(Contato contato)
    {
        _contatos.Remove(contato);
    }

    public void AdicionarDocumento(Documento documento)
    {
        _documentos.Add(documento);
    }

    public void RemoverDocumento(Documento documento)
    {
        _documentos.Remove(documento);
    }

    public void AdicionarEndereco(Endereco endereco)
    {
        Endereco = endereco;
    }
}