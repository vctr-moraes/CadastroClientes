using System.Diagnostics.CodeAnalysis;

namespace CadastroClientes.Business.Models;

[ExcludeFromCodeCoverage]
public class Cliente
{
    private readonly List<Contato> _contatos;
    private readonly List<Documento> _documentos;
    public string NomeFantasia { get; private set; }
    public string RazaoSocial { get; private set; }
    public string Cnpj { get; private set; }
    public Endereco Endereco { get; private set; }

    public IReadOnlyCollection<Contato> Contatos => _contatos;

    public IReadOnlyCollection<Documento> Documentos => _documentos;
}