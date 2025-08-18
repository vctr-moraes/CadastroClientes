using System.Diagnostics.CodeAnalysis;
using CadastroClientes.Data.Context;

namespace CadastroClientes.App.Configurations;

[ExcludeFromCodeCoverage]
public static class DependencyInjectionConfig
{
    public static IServiceCollection ResolveDependencies(this IServiceCollection services)
    {
        services.AddScoped<CadastroClientesDbContext>();

        return services;
    }
}