using CadastroClientes.Business.Interfaces;
using CadastroClientes.Business.Models;
using CadastroClientes.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CadastroClientes.Data.Repository;

public class EnderecoRepository : IEnderecoRepository
{
    private readonly CadastroClientesDbContext _context;

    public EnderecoRepository(CadastroClientesDbContext context)
    {
        _context = context;
    }

    public async Task<Endereco> ObterPorId(Guid id)
    {
        return await _context.Enderecos.FindAsync(id);
    }

    public async Task<IList<Endereco>> ObterTodos()
    {
        return await _context.Enderecos.AsNoTracking().ToListAsync();
    }

    public void Adicionar(Endereco endereco)
    {
        _context.Enderecos.Add(endereco);
        _context.SaveChanges();
    }

    public void Atualizar(Endereco endereco)
    {
        _context.Enderecos.Update(endereco);
        _context.SaveChanges();
    }

    public void Remover(Guid id)
    {
        var endereco = ObterPorId(id);
        _context.Enderecos.Remove(endereco.Result);
        _context.SaveChanges();
    }
}