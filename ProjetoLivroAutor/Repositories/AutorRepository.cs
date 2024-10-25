using Microsoft.EntityFrameworkCore;
using ProjetoLivroAutor.Context;
using ProjetoLivroAutor.Models;
using static ProjetoLivroAutor.Repositories.AutorRepository;

namespace ProjetoLivroAutor.Repositories
{
    public class AutorRepository : IAutorRepository
    {
        private readonly AppDbContext _context;

        public AutorRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Autor>> BuscarAutores()
        {
            return await _context.Autores.ToListAsync();
        }
        public async Task<IEnumerable<Autor>> BuscarAutorLivros()
        {
            return await _context.Autores.Include(c => c.Livros).ToListAsync();
        }
        public async Task<Autor> BuscarAutorPorId(int id)
        {
            return await _context.Autores.Where(c => c.AutorId == id).FirstOrDefaultAsync();
        }
        public async Task<Autor> CriarAutor(Autor autor)
        {
            _context.Autores.Add(autor);
            await _context.SaveChangesAsync();
            return autor;
        }
        public async Task<Autor> Atualizar(Autor autor)
        {
            _context.Entry(autor).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return autor;
        }
        public async Task<Autor> Deletar(int id)
        {
            var autor = await BuscarAutorPorId(id);
            _context.Autores.Remove(autor);
            await _context.SaveChangesAsync();
            return autor;
        }
    }
}