using CadastroClientes.Business.Interfaces;
using CadastroClientes.Business.Models;
using CadastroClientes.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CadastroClientes.Data.Repository;

public class ContatoRepository : IContatoRepository
{
    private readonly CadastroClientesDbContext _context;

    public ContatoRepository(CadastroClientesDbContext context)
    {
        _context = context;
    }

    public async Task<Contato> ObterPorId(Guid id)
    {
        return await _context.Contatos.FindAsync(id);
    }

    public async Task<IList<Contato>> ObterTodos()
    {
        return await _context.Contatos.AsNoTracking().ToListAsync();
    }

    public void Adicionar(Contato contato)
    {
        _context.Contatos.Add(contato);
        _context.SaveChanges();
    }

    public void AdicionarVarios(IList<Contato> contatos)
    {
        _context.Contatos.AddRange(contatos);
        _context.SaveChanges();
    }

    public void Atualizar(Contato contato)
    {
        _context.Contatos.Update(contato);
        _context.SaveChanges();
    }

    public void Remover(Guid id)
    {
        var contato = ObterPorId(id);
        _context.Contatos.Remove(contato.Result);
        _context.SaveChanges();
    }
}