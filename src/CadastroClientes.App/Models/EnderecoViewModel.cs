using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace CadastroClientes.App.Models;

[ExcludeFromCodeCoverage]
public class EnderecoViewModel
{
    [Key] public Guid Id { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    [StringLength(200, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres.")]
    [Display(Name = "Logradouro")]
    [DataType(DataType.Text)]
    public string Logradouro { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    [StringLength(20, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres.")]
    [Display(Name = "Número")]
    [DataType(DataType.Text)]
    public string Numero { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    [StringLength(50, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres.")]
    [Display(Name = "Bairro")]
    [DataType(DataType.Text)]
    public string Bairro { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    [StringLength(50, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres.")]
    [Display(Name = "Cidade")]
    [DataType(DataType.Text)]
    public string Cidade { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    [StringLength(50, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres.")]
    [Display(Name = "Estado")]
    [DataType(DataType.Text)]
    public string Estado { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    [StringLength(50, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres.")]
    [Display(Name = "País")]
    [DataType(DataType.Text)]
    public string Pais { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    [StringLength(50, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres.")]
    [Display(Name = "CEP")]
    [DataType(DataType.Text)]
    public string Cep { get; set; }

    [ForeignKey("Cliente")] public Guid ClienteId { get; set; }
}