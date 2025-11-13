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

    public async Task Remover(Guid id)
    {
        var cliente = await _clienteRepository.ObterPorId(id);

        if (cliente.Documentos.Any())
        {
            throw new InvalidOperationException("O cliente possui documentos associados e não pode ser removido.");
        }

        _clienteRepository.Remover(id);
    }
}