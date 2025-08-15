using System.Diagnostics.CodeAnalysis;

namespace CadastroClientes.Core.DomainObjects;

[ExcludeFromCodeCoverage]
public abstract class Entity
{
    protected Entity()
    {
        Id = Guid.NewGuid();
    }

    public Guid Id { get; set; }
}