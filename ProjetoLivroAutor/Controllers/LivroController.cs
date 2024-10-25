using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoLivroAutor.DTOs;
using ProjetoLivroAutor.Services;

namespace ProjetoLivroAutor.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LivroController : ControllerBase
{
    private readonly ILivroService _livroService;

    public LivroController(ILivroService livroService)
    {
        _livroService = livroService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<LivroDTO>>> BuscarLivros()
    {
        var livrosDTO = await _livroService.BuscarLivros();
        if (livrosDTO is null)
        {
            return NotFound("Livros não encontrados");
        }
        return Ok(livrosDTO);
    }

    [HttpGet("Livros&Autores")]
    public async Task<ActionResult<IEnumerable<LivroDTO>>> BuscarLivrosAutor()
    {
        var livrosDTO = await _livroService.BuscarLivroAutor();

        if (livrosDTO is null)
            return NotFound("Livros e autores não encontrados");

        return Ok(livrosDTO);
    }

    [HttpGet("{id:int}", Name = "ObterLivro")]
    public async Task<ActionResult<LivroDTO>> BuscarLivroPorId(int id)
    {
        var livrosDTO = await _livroService.BuscarLivroPorId(id);

        if (livrosDTO is null)
            return NotFound("Livro não encontrado pelo id");

        return Ok(livrosDTO);
    }

    [HttpPost]
    //[Authorize]
    public async Task<ActionResult> CriarLivro([FromBody] LivroDTO livroDTO)
    {
        if (livroDTO is null)
            return BadRequest("Não foi possível criar um livro");

        await _livroService.CriarLivro(livroDTO);

        return new CreatedAtRouteResult("ObterLivro", new { id = livroDTO.LivroId }, livroDTO);
    }

    [HttpPut("{id:int}")]
    //[Authorize]
    public async Task<ActionResult> Atualizar(int id, [FromBody] LivroDTO livroDTO)
    {
        if (id != livroDTO.LivroId)
            return BadRequest();

        if (livroDTO is null)
            return NotFound();
        await _livroService.Atualizar(livroDTO);
        return Ok(livroDTO);
    }

    [HttpDelete("{id:int}")]
   //[Authorize]
    public async Task<ActionResult<LivroDTO>> Deletar(int id)
    {
        var livroDTO = await _livroService.BuscarLivroPorId(id);
        if (livroDTO is null)
        {
            return NotFound("Dono não encontradado");
        }

        await _livroService.Deletar(id);
        return Ok(livroDTO);
    }
}

