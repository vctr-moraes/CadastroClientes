using System.Diagnostics.CodeAnalysis;
using CadastroClientes.Business.Interfaces;
using CadastroClientes.Business.Services;
using CadastroClientes.Data.Context;
using CadastroClientes.Data.Repository;

namespace CadastroClientes.App.Configurations;

[ExcludeFromCodeCoverage]
public static class DependencyInjectionConfig
{
    public static IServiceCollection ResolveDependencies(this IServiceCollection services)
    {
        services.AddScoped<CadastroClientesDbContext>();

        services.AddScoped<IClienteRepository, ClienteRepository>();
        services.AddScoped<IContatoRepository, ContatoRepository>();
        services.AddScoped<IDocumentoRepository, DocumentoRepository>();
        services.AddScoped<IEnderecoRepository, EnderecoRepository>();
        
        services.AddScoped<IClienteService, ClienteService>();
        services.AddScoped<IContatoService, ContatoService>();
        services.AddScoped<IDocumentoService, DocumentoService>();

        return services;
    }
}