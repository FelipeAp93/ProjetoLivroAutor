using AutoMapper;
using ProjetoLivroAutor.Models;

namespace ProjetoLivroAutor.DTOs.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Autor, AutorDTO>().ReverseMap();
        CreateMap<Livro, LivroDTO>().ReverseMap();
        CreateMap<AutorCreateDTO, Autor>();
    }

}
