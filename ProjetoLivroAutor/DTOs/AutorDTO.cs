using ProjetoLivroAutor.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProjetoLivroAutor.DTOs;

public class AutorDTO
{
    public int AutorId { get; set; }
    [Required(ErrorMessage = "O nome é obrigatório.")]
    [MinLength(3)]
    [MaxLength(35)]
    public string? Nome { get; set; }

    [MinLength(3)]
    [MaxLength(50)]
    public string? Sobrenome { get; set; }

    
    public ICollection<Livro>? Livros { get; set; }

}
