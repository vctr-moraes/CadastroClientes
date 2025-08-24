using System.ComponentModel.DataAnnotations;

namespace CadastroClientes.App.Models;

public enum TipoDocumentoViewModel
{
    [Display(Name = "Contrato")] Contrato = 1,

    [Display(Name = "Certidão")] Certidao = 2,

    [Display(Name = "Certificado")] Certificado = 3
}