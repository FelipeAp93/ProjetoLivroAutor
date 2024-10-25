using Microsoft.EntityFrameworkCore;
using ProjetoLivroAutor.Context;
using ProjetoLivroAutor.Models;

namespace ProjetoLivroAutor.Repositories;

public class LivroRepository : ILivroRepository
{
    private readonly AppDbContext _context;

    public LivroRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Livro>> BuscarLivros()
    {
        return await _context.Livros.ToListAsync();
    }
    public async Task<IEnumerable<Livro>> BuscarLivroAutor()
    {
        return await _context.Livros.Include(p => p.Autor).ToListAsync();
    }
    public async Task<Livro> BuscarLivroPorId(int id)
    {
        return await _context.Livros.Where(p => p.LivroId == id).FirstOrDefaultAsync();
    }
    public async Task<Livro> CriarLivro(Livro livro)
    {
        _context.Livros.Add(livro);
        await _context.SaveChangesAsync();
        return livro;
    }
    public async Task<Livro> Atualizar(Livro livro)
    {
        _context.Entry(livro).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return livro;
    }
    public async Task<Livro> Deletar(int id)
    {
        var livro = await BuscarLivroPorId(id);
        _context.Livros.Remove(livro);
        await _context.SaveChangesAsync();
        return livro;
    }
}


