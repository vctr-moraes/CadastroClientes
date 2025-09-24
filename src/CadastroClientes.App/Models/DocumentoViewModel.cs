using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using CadastroClientes.Business.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CadastroClientes.App.Models;

[ExcludeFromCodeCoverage]
public class DocumentoViewModel
{
    public DocumentoViewModel()
    {
    }

    public DocumentoViewModel(Documento documento)
    {
        Id = documento.Id;
        Descricao = documento.Descricao;
        NomeArquivo = documento.NomeArquivo;
        DataHoraCriacao = documento.DataHoraCriacao;
        TipoDocumento = (TipoDocumentoViewModel)documento.TipoDocumento;
    }

    [Key] public Guid Id { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [StringLength(500, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres.")]
    [Display(Name = "Descrição")]
    [DataType(DataType.Text)]
    public string Descricao { get; set; }

    [Display(Name = "Nome do Arquivo")] public string? NomeArquivo { get; set; }

    public string? ChaveAcessoArmazenamento { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}", ApplyFormatInEditMode = true)]
    [Display(Name = "Data e Hora de Criação")]
    [DataType(DataType.DateTime)]
    public DateTime DataHoraCriacao { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    [Display(Name = "Arquivo")]
    [DataType(DataType.Upload)]
    public IFormFile Arquivo { get; set; }

    [Display(Name = "Tipo de Documento")] public TipoDocumentoViewModel TipoDocumento { get; set; }

    [ForeignKey("Cliente")] public Guid ClienteId { get; set; }
}