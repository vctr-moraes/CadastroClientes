using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CadastroClientes.App.Models;

[ExcludeFromCodeCoverage]
public class DocumentoViewModel
{
    [Key] public Guid Id { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [StringLength(500, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres.")]
    [Display(Name = "Descrição")]
    [DataType(DataType.Text)]
    public string Descricao { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    [Display(Name = "Data e Hora de Criação")]
    [DataType(DataType.DateTime)]
    public DateTime DataHoraCriacao { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    [Display(Name = "Tipo de Documento")]
    public List<TipoDocumentoViewModel> TipoDocumentos { get; set; }

    public List<SelectListItem> TipoDocumentosSelectListItem { get; set; }
    public TipoDocumentoViewModel TipoDocumento { get; set; }

    [ForeignKey("Cliente")] public Guid ClienteId { get; set; }
}