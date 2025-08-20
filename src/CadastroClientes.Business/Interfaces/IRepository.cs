using CadastroClientes.Core.DomainObjects;

namespace CadastroClientes.Business.Interfaces;

public interface IRepository<TEntity> where TEntity : Entity
{
    Task<TEntity> ObterPorId(Guid id);
    Task<IList<TEntity>> ObterTodos();
    Task Adicionar(TEntity entity);
    Task AdicionarVarios(IList<TEntity> entities);
    Task Atualizar(TEntity entity);
    Task Remover(Guid id);
    Task SaveChanges();
}