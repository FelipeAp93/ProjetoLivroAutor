using ProjetoLivroAutor.DTOs;

namespace ProjetoLivroAutor.Services;

public interface ILivroService
{
     Task<IEnumerable<LivroDTO>> BuscarLivros();
    Task<IEnumerable<LivroDTO>> BuscarLivroAutor();
    Task<LivroDTO> BuscarLivroPorId(int id);
    Task CriarLivro(LivroDTO livroDTO);
    Task Atualizar(LivroDTO livroDTO);
    Task Deletar(int id);
}
