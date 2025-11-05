using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using CadastroClientes.Business.Models;

namespace CadastroClientes.App.Models;

[ExcludeFromCodeCoverage]
public class ClienteDetailsViewModel
{
    public ClienteDetailsViewModel()
    {
    }

    public ClienteDetailsViewModel(Cliente cliente)
    {
        Id = cliente.Id;
        NomeFantasia = cliente.NomeFantasia;
        RazaoSocial = cliente.RazaoSocial;
        Cnpj = cliente.Cnpj;
        DataCadastro = cliente.DataCadastro;
        Contatos = cliente.Contatos.Select(contato => new ContatoViewModel(contato)).ToList();
        Documentos = cliente.Documentos.Select(doc => new DocumentoViewModel(doc)).ToList();
        Endereco = new EnderecoViewModel(cliente.Endereco);
    }

    [Key] public Guid Id { get; set; }

    [Display(Name = "Nome Fantasia")] public string NomeFantasia { get; set; }

    [Display(Name = "Razão Social")] public string RazaoSocial { get; set; }

    [Display(Name = "CNPJ")] public string Cnpj { get; set; }

    [Display(Name = "Data de Cadastro")]
    [Editable(false)]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
    public DateTime DataCadastro { get; set; }

    [Display(Name = "Endereço")] public EnderecoViewModel Endereco { get; set; }

    [Display(Name = "Contatos")] public ContatoViewModel? Contato { get; set; }

    [Display(Name = "Contatos")] public List<ContatoViewModel> Contatos { get; set; }

    [Display(Name = "Documentos")] public DocumentoViewModel? Documento { get; set; }

    public List<DocumentoViewModel>? Documentos { get; set; }
}