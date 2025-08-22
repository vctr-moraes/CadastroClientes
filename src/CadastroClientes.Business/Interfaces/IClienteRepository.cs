using CadastroClientes.Business.Models;

namespace CadastroClientes.Business.Interfaces;

public interface IClienteRepository
{
    Task<Cliente> ObterPorId(Guid id);
    Task<IList<Cliente>> ObterTodos();
    void Adicionar(Cliente cliente);
    void Atualizar(Cliente cliente);
    void Remover(Guid id);
}