using CadastroClientes.Business.Models;

namespace CadastroClientes.Business.Interfaces;

public interface IClienteService
{
    void Adicionar(Cliente cliente);
    void Atualizar(Cliente cliente);
    Task Remover(Guid id);
}