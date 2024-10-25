using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoLivroAutor.DTOs;
using ProjetoLivroAutor.Models;
using ProjetoLivroAutor.Services;

namespace ProjetoLivroAutor.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AutorController : ControllerBase
{
    private readonly IAutorService _autorService;
    private readonly IMapper _mapper;

    public AutorController(IAutorService autorService, IMapper mapper)
    {
        _autorService = autorService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AutorDTO>>> Buscar()
    {
        var autorDTO = await _autorService.BuscarAutores();

        if (autorDTO is null)
            return NotFound("Autores não encontrados");

        return Ok(autorDTO);
    }

    [HttpGet("Autor&Livros")]
    public async Task<ActionResult<IEnumerable<AutorDTO>>> BuscarAutorLivro()
    {
        var autorDTO = await _autorService.BuscarAutorLivro();

        if (autorDTO is null)
            return NotFound("Autor e livro não encontrados");

        return Ok(autorDTO);
    }


    [HttpGet("{id:int}", Name = "ObterAutor")]
    public async Task<ActionResult<AutorDTO>> BuscarAutorPorId(int id)
    {
        var autorDTO = await _autorService.BuscarAutorPorId(id);

        if (autorDTO is null)
            return NotFound("Autor não encontrado pelo id");

        return Ok(autorDTO);
    }

    [HttpPost]
    // [Authorize]
    public async Task<ActionResult> Criar([FromBody] AutorCreateDTO autorCreateDTO)
    {
        if (autorCreateDTO is null)
            return BadRequest("Não foi possível criar o autor.");

        await _autorService.AdicionarAutor(autorCreateDTO);

        return CreatedAtRoute("ObterAutor", new { id = autorCreateDTO.Id }, autorCreateDTO);
    }




    [HttpPut("{id:int}")]
    //[Authorize]
    public async Task<ActionResult> Atualizar(int id, [FromBody] AutorDTO autorDTO)
    {
        if (id != autorDTO.AutorId)
            return BadRequest();

        if (autorDTO is null)
            return NotFound();
        await _autorService.Atualizar(autorDTO);
        return Ok(autorDTO);
    }

    [HttpDelete("{id:int}")]
    //[Authorize]
    public async Task<ActionResult<AutorDTO>> Deletar(int id)
    {
        var autorDTO = await _autorService.BuscarAutorPorId(id);
        if (autorDTO is null)
        {
            return NotFound("Autor não encontradado");
        }

        await _autorService.Deletar(id);
        return Ok(autorDTO);
    }
}


