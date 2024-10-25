using AutoMapper;
using ProjetoLivroAutor.DTOs;
using ProjetoLivroAutor.Models;
using ProjetoLivroAutor.Repositories;

namespace ProjetoLivroAutor.Services
{
    public class AutorService : IAutorService
    {
        private readonly IAutorRepository _autorRepository;
        private readonly IMapper _mapper;

        public AutorService(IAutorRepository autorRepository, IMapper mapper)
        {
            _autorRepository = autorRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AutorDTO>> BuscarAutores()
        {
            var autorEntity = await _autorRepository.BuscarAutores();
            return _mapper.Map<IEnumerable<AutorDTO>>(autorEntity);
        }

        public async Task<IEnumerable<AutorDTO>> BuscarAutorLivro()
        {
            var autorEntity = await _autorRepository.BuscarAutorLivros();
            return _mapper.Map<IEnumerable<AutorDTO>>(autorEntity);
        }
        public async Task<AutorDTO> BuscarAutorPorId(int id)
        {
            var autorEntity = await _autorRepository.BuscarAutorPorId(id);
            return _mapper.Map<AutorDTO>(autorEntity);
        }
        public async Task CriarAutor(AutorDTO autorDTO)
        {
            var autorEntity = _mapper.Map<Autor>(autorDTO);
            await _autorRepository.CriarAutor(autorEntity);
            autorDTO.AutorId = autorEntity.AutorId;
        }
        public async Task Atualizar(AutorDTO autorDTO)
        {
            var autorEntity = _mapper.Map<Autor>(autorDTO);
            await _autorRepository.Atualizar(autorEntity);
        }
        public async Task Deletar(int id)
        {
            var autorEntity = _autorRepository.BuscarAutorPorId(id).Result;
            await _autorRepository.Deletar(autorEntity.AutorId);
        }

        public async Task AdicionarAutor(AutorCreateDTO autorCreateDTO)
        {
            var autorEntity = _mapper.Map<Autor>(autorCreateDTO);
            await _autorRepository.CriarAutor(autorEntity);
            autorCreateDTO.Id = autorEntity.AutorId;
        }
    }
}

