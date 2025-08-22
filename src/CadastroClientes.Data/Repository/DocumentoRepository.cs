using CadastroClientes.Business.Interfaces;
using CadastroClientes.Business.Models;
using CadastroClientes.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CadastroClientes.Data.Repository;

public class DocumentoRepository : IDocumentoRepository
{
    private readonly CadastroClientesDbContext _context;

    public DocumentoRepository(CadastroClientesDbContext context)
    {
        _context = context;
    }

    public async Task<Documento> ObterPorId(Guid id)
    {
        return await _context.Documentos.FindAsync(id);
    }

    public async Task<IList<Documento>> ObterTodos()
    {
        return await _context.Documentos.AsNoTracking().ToListAsync();
    }

    public void Adicionar(Documento documento)
    {
        _context.Documentos.Add(documento);
        _context.SaveChanges();
    }

    public void AdicionarVarios(IList<Documento> documentos)
    {
        _context.Documentos.AddRange(documentos);
    }

    public void Atualizar(Documento documento)
    {
        _context.Documentos.Update(documento);
        _context.SaveChanges();
    }

    public void Remover(Guid id)
    {
        var documento = ObterPorId(id);
        _context.Documentos.Remove(documento.Result);
        _context.SaveChanges();
    }
}