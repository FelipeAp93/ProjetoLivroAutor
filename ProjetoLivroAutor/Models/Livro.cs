namespace ProjetoLivroAutor.Models;

public class Livro
{
    public int LivroId { get; set; } 
    public string? Nome { get; set; }
    public string? Descricao { get; set; }
    public Autor? Autor { get; set; }
    public int AutorId { get; set; }
}
