using System.Text.Json.Serialization;

namespace ProjetoLivroAutor.Models;

public class Autor
{
    public int AutorId { get; set; }
    public string? Nome { get; set; }
    public string? Sobrenome { get; set; }
     
    [JsonIgnore]
    public ICollection<Livro>? Livros { get; set; }

}
