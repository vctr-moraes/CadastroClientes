using CadastroClientes.Business.Interfaces;
using CadastroClientes.Business.Models;
using CadastroClientes.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CadastroClientes.Data.Repository;

public class ClienteRepository : IClienteRepository
{
    private readonly CadastroClientesDbContext _context;

    public ClienteRepository(CadastroClientesDbContext context)
    {
        _context = context;
    }

    public async Task<Cliente> ObterPorId(Guid id)
    {
        return await _context.Clientes.FindAsync(id);
    }

    public async Task<IList<Cliente>> ObterTodos()
    {
        return await _context.Clientes.AsNoTracking().ToListAsync();
    }

    public void Adicionar(Cliente cliente)
    {
        _context.Clientes.Add(cliente);
        _context.SaveChanges();
    }

    public void Atualizar(Cliente cliente)
    {
        _context.Clientes.Update(cliente);
        _context.SaveChanges();
    }

    public void Remover(Guid id)
    {
        var cliente = ObterPorId(id);
        _context.Clientes.Remove(cliente.Result);
        _context.SaveChanges();
    }
}