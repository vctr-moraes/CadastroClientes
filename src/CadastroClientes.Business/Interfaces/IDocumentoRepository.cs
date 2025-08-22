using CadastroClientes.Business.Models;

namespace CadastroClientes.Business.Interfaces;

public interface IDocumentoRepository
{
    Task<Documento> ObterPorId(Guid id);
    Task<IList<Documento>> ObterTodos();
    void Adicionar(Documento documento);
    void AdicionarVarios(IList<Documento> documentos);
    void Atualizar(Documento documento);
    void Remover(Guid id);
}