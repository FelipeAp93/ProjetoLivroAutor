using ProjetoLivroAutor.Models;

namespace ProjetoLivroAutor.Repositories;

public interface IAutorRepository
{
    Task<IEnumerable<Autor>> BuscarAutores();
    Task<IEnumerable<Autor>> BuscarAutorLivros();
    Task<Autor> BuscarAutorPorId(int id);
    Task<Autor> CriarAutor(Autor autor);
    Task<Autor> Atualizar(Autor autor);
    Task<Autor> Deletar(int id);
}
