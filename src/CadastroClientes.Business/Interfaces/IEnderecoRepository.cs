using CadastroClientes.Business.Models;

namespace CadastroClientes.Business.Interfaces;

public interface IEnderecoRepository
{
    Task<Endereco> ObterPorId(Guid id);
    Task<IList<Endereco>> ObterTodos();
    void Adicionar(Endereco endereco);
    void Atualizar(Endereco endereco);
    void Remover(Guid id);
}