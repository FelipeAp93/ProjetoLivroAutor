using ProjetoLivroAutor.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProjetoLivroAutor.DTOs;

public class LivroDTO
{
    public int LivroId { get; set; }
    [Required(ErrorMessage = "O nome é obrigatório.")]
    [MinLength(3)]
    [MaxLength(70)]
    public string? Nome { get; set; }

    [Required(ErrorMessage = "O descrição é obrigatória.")]
    [MinLength(3)]
    [MaxLength(250)]
    public string? Descricao { get; set; }
    [JsonIgnore]
    public Autor? Autor { get; set; }
    public int AutorId { get; set; }
}
