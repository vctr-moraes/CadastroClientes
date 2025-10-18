using CadastroClientes.Business.Interfaces;
using CadastroClientes.Business.Models;

namespace CadastroClientes.Business.Services;

public class ClienteService : IClienteService
{
    private readonly IClienteRepository _clienteRepository;

    public ClienteService(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }
    
    public void Adicionar(Cliente cliente)
    {
        _clienteRepository.Adicionar(cliente);
    }

    public void Atualizar(Cliente cliente)
    {
        _clienteRepository.Atualizar(cliente);
    }

    public void Remover(Guid id)
    {
        _clienteRepository.Remover(id);
    }
}