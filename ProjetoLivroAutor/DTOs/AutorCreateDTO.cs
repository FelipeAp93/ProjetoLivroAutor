using System.ComponentModel.DataAnnotations;

namespace ProjetoLivroAutor.DTOs;

public class AutorCreateDTO
{
    public  int Id { get; set; }
    [Required(ErrorMessage = "O nome é obrigatório.")]
    [MinLength(3)]
    [MaxLength(35)]
    public string? Nome { get; set; }

    [MinLength(3)]
    [MaxLength(50)]
    public string? Sobrenome { get; set; }
}
