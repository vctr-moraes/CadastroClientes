using CadastroClientes.Business.Models;

namespace CadastroClientes.Business.Interfaces;

public interface IContatoRepository
{
    Task<Contato> ObterPorId(Guid id);
    Task<IList<Contato>> ObterTodos();
    void Adicionar(Contato contato);
    void AdicionarVarios(IList<Contato> contatos);
    void Atualizar(Contato contato);
    void Remover(Guid id);
}