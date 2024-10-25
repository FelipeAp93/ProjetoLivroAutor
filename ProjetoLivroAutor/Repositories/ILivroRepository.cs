using ProjetoLivroAutor.Models;

namespace ProjetoLivroAutor.Repositories;

public interface ILivroRepository
{
    Task<IEnumerable<Livro>> BuscarLivros();
    Task<IEnumerable<Livro>> BuscarLivroAutor();
    Task<Livro> BuscarLivroPorId(int id);
    Task<Livro> CriarLivro(Livro livro);
    Task<Livro> Atualizar(Livro livro);
    Task<Livro> Deletar(int id);
}
