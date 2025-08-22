using System.Diagnostics.CodeAnalysis;
using CadastroClientes.Business.Interfaces;
using CadastroClientes.Core.DomainObjects;
using CadastroClientes.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CadastroClientes.Data.Repository;

[ExcludeFromCodeCoverage]
public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
{
    private readonly CadastroClientesDbContext _context;

    public Repository(CadastroClientesDbContext context)
    {
        _context = context;
    }

    public virtual async Task<TEntity> ObterPorId(Guid id)
    {
        return await _context.FindAsync<TEntity>(id)
               ?? throw new KeyNotFoundException($"Entity of type {typeof(TEntity).Name} with ID {id} not found.");
    }

    public virtual async Task<IList<TEntity>> ObterTodos()
    {
        return await _context.Set<TEntity>().ToListAsync();
    }

    public virtual async Task Adicionar(TEntity entity)
    {
        _context.Add(entity);
        await SaveChanges();
    }

    public virtual async Task AdicionarVarios(IList<TEntity> entities)
    {
        _context.AddRange(entities);
        await SaveChanges();
    }

    public virtual async Task Atualizar(TEntity entity)
    {
        _context.Update(entity);
        await SaveChanges();
    }

    public virtual async Task Remover(Guid id)
    {
        _context.Remove(new TEntity { Id = id });
        await SaveChanges();
    }

    public async Task SaveChanges()
    {
        await _context.SaveChangesAsync();
    }
}