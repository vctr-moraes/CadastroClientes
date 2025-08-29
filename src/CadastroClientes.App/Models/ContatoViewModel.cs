using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using CadastroClientes.Business.Models;

namespace CadastroClientes.App.Models;

[ExcludeFromCodeCoverage]
public class ContatoViewModel
{
    public ContatoViewModel(Contato contato)
    {
        Id = contato.Id;
        DescricaoContato = contato.DescricaoContato;
        NomeRepresentante = contato.NomeRepresentante;
        Cargo = contato.Cargo;
        EmailRepresentante = contato.EmailRepresentante;
        TelefoneRepresentante = contato.TelefoneRepresentante;
        EmailComercial = contato.EmailComercial;
        TelefoneComercial = contato.TelefoneComercial;
    }

    [Key] public Guid Id { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    [StringLength(300, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres.")]
    [Display(Name = "Descrição do Contato")]
    [DataType(DataType.MultilineText)]
    public string DescricaoContato { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    [StringLength(100, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres.")]
    [Display(Name = "Nome do Representante")]
    [DataType(DataType.Text)]
    public string NomeRepresentante { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    [StringLength(100, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres.")]
    [Display(Name = "Cargo")]
    [DataType(DataType.Text)]
    public string Cargo { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    [StringLength(100, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres.")]
    [Display(Name = "Email do Representante")]
    [DataType(DataType.EmailAddress)]
    public string EmailRepresentante { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    [StringLength(20, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres.")]
    [Display(Name = "Telefone do Representante")]
    [DataType(DataType.PhoneNumber)]
    public string TelefoneRepresentante { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    [StringLength(100, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres.")]
    [Display(Name = "Email Comercial")]
    [DataType(DataType.EmailAddress)]
    public string EmailComercial { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    [StringLength(20, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres.")]
    [Display(Name = "Telefone Comercial")]
    [DataType(DataType.PhoneNumber)]
    public string TelefoneComercial { get; set; }

    [ForeignKey("Cliente")] public Guid ClienteId { get; set; }
}