using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using CadastroClientes.Business.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CadastroClientes.App.Models;

[ExcludeFromCodeCoverage]
public class ClienteViewModel
{
    public ClienteViewModel()
    {
        
    }

    public ClienteViewModel(Cliente cliente)
    {
        Id = cliente.Id;
        NomeFantasia = cliente.NomeFantasia;
        RazaoSocial = cliente.RazaoSocial;
        Cnpj = cliente.Cnpj;
        DataCadastro = cliente.DataCadastro;
        Contato = cliente.Contatos.FirstOrDefault() != null
            ? new ContatoViewModel(cliente.Contatos.FirstOrDefault())
            : null;
        Contatos = cliente.Contatos.Select(contato => new ContatoViewModel(contato)).ToList();
        Documento = new DocumentoViewModel();
        Endereco = new EnderecoViewModel
        {
            Logradouro = cliente.Endereco.Logradouro,
            Numero = cliente.Endereco.Numero,
            Bairro = cliente.Endereco.Bairro,
            Cidade = cliente.Endereco.Cidade,
            Estado = cliente.Endereco.Estado,
            Pais = cliente.Endereco.Pais,
            Cep = cliente.Endereco.Cep
        };
    }

    [Key] public Guid Id { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    [StringLength(100, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres.")]
    [Display(Name = "Nome Fantasia")]
    [DataType(DataType.Text)]
    public string NomeFantasia { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    [StringLength(100, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres.")]
    [Display(Name = "Razão Social")]
    [DataType(DataType.Text)]
    public string RazaoSocial { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    [StringLength(50, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres.")]
    [Display(Name = "CNPJ")]
    [DataType(DataType.Text)]
    public string Cnpj { get; set; }

    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    [Display(Name = "Data de Cadastro")]
    [DataType(DataType.Date)]
    [Editable(false)]
    public DateTime DataCadastro { get; set; }

    [Display(Name = "Endereço")] public EnderecoViewModel Endereco { get; set; }

    [Display(Name = "Contatos")] public ContatoViewModel Contato { get; set; }

    [Display(Name = "Contatos")] public List<ContatoViewModel> Contatos { get; set; } = new List<ContatoViewModel>();

    [Display(Name = "Documentos")]
    public DocumentoViewModel? Documento { get; set; }

    public List<DocumentoViewModel>? Documentos { get; set; }
}