using Microsoft.EntityFrameworkCore;
using ProjetoLivroAutor.Models;

namespace ProjetoLivroAutor.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Autor> Autores { get; set; }
    public DbSet<Livro> Livros { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        // Fluent API

        // Autor
        modelBuilder.Entity<Autor>(entity =>
        {
            entity.HasKey(c => c.AutorId);
            entity.Property(c => c.Nome).IsRequired().HasMaxLength(35);
            entity.Property(c => c.Sobrenome).IsRequired().HasMaxLength(50);

            // Um Autor possui muitos Livros
            entity.HasMany(c => c.Livros)
                  .WithOne(p => p.Autor)
                  .HasForeignKey(p => p.AutorId);
        });

        // Livro
        modelBuilder.Entity<Livro>(entity =>
        {
            entity.HasKey(c => c.LivroId);
            entity.Property(c => c.Nome).IsRequired().HasMaxLength(70);
            entity.Property(c => c.Descricao).IsRequired().HasMaxLength(250);

            // Um Livro tem um único Autor
            entity.HasOne(c => c.Autor)
                  .WithMany(a => a.Livros)
                  .HasForeignKey(c => c.AutorId);
        });
    }
}




