using CadastroClientes.Business.Models;

namespace CadastroClientes.Business.Interfaces;

public interface IDocumentoService
{
    void Adicionar(Documento documento);
    void Remover(Guid id);
}