using AutoMapper;
using ProjetoLivroAutor.DTOs;
using ProjetoLivroAutor.Models;
using ProjetoLivroAutor.Repositories;

namespace ProjetoLivroAutor.Services;

public class LivroService : ILivroService
{
    private readonly ILivroRepository _livroRepository;
    private readonly IMapper _mapper;

    public LivroService(ILivroRepository livroRepository, IMapper mapper)
    {
        _livroRepository = livroRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<LivroDTO>> BuscarLivros()
    {
        var livrosEntity = await _livroRepository.BuscarLivros();
        return _mapper.Map<IEnumerable<LivroDTO>>(livrosEntity);
    }

    public async Task<IEnumerable<LivroDTO>> BuscarLivroAutor()
    {
        var livroEntity = await _livroRepository.BuscarLivroAutor();
        return _mapper.Map<IEnumerable<LivroDTO>>(livroEntity);
    }

    public async Task<LivroDTO> BuscarLivroPorId(int id)
    {
        var livroEntity = await _livroRepository.BuscarLivroPorId(id);
        return _mapper.Map<LivroDTO>(livroEntity);
    }

    public async Task CriarLivro(LivroDTO livroDTO)
    {
        var livroEntity = _mapper.Map<Livro>(livroDTO);
        await _livroRepository.CriarLivro(livroEntity);
        livroDTO.LivroId = livroEntity.LivroId;
    }
    public async Task Atualizar(LivroDTO livroDTO)
    {
        var livroEntity = _mapper.Map<Livro>(livroDTO);
        await _livroRepository.Atualizar(livroEntity);
    }

    public async Task Deletar(int id)
    {
        var livroEntity = await _livroRepository.BuscarLivroPorId (id);
        await _livroRepository.Deletar(livroEntity.LivroId);
    }
}
