using CadastroClientes.Business.Interfaces;
using CadastroClientes.Business.Models;

namespace CadastroClientes.Business.Services;

public class DocumentoService : IDocumentoService
{
    private readonly IDocumentoRepository _documentoRepository;

    public DocumentoService(IDocumentoRepository documentoRepository)
    {
        _documentoRepository = documentoRepository;
    }
    
    public void Adicionar(Documento documento)
    {
        _documentoRepository.Adicionar(documento);
    }

    public void Remover(Guid id)
    {
        _documentoRepository.Remover(id);
    }
}