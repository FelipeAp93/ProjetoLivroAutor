using ProjetoLivroAutor.DTOs;
using ProjetoLivroAutor.Models;

namespace ProjetoLivroAutor.Services;

public interface IAutorService
{
    Task<IEnumerable<AutorDTO>> BuscarAutores();
    Task<IEnumerable<AutorDTO>> BuscarAutorLivro();
    Task AdicionarAutor(AutorCreateDTO autorCreateDTO);

    Task<AutorDTO> BuscarAutorPorId(int id);
    Task CriarAutor(AutorDTO autorDTO);
    Task Atualizar(AutorDTO autorDTO);
    Task Deletar(int id);
    
}
