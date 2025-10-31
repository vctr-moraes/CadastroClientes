using CadastroClientes.Business.Interfaces;
using CadastroClientes.Business.Models;

namespace CadastroClientes.Business.Services;

public class ContatoService : IContatoService
{
    private readonly IContatoRepository _contatoRepository;

    public ContatoService(IContatoRepository contatoRepository)
    {
        _contatoRepository = contatoRepository;
    }

    public void Adicionar(Contato contato)
    {
        _contatoRepository.Adicionar(contato);
    }

    public void Remover(Guid id)
    {
        _contatoRepository.Remover(id);
    }
}