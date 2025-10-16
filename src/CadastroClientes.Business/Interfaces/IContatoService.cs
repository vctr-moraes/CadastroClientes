using CadastroClientes.Business.Models;

namespace CadastroClientes.Business.Interfaces;

public interface IContatoService
{
    void Adicionar(Contato contato);
    void Remover(Guid id);
}