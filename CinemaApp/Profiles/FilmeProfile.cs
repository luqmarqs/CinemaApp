using AutoMapper;
using CinemaApp.Data.Dtos;

namespace CinemaApp.Profiles
{
    public class FilmeProfile : Profile
    {
        public FilmeProfile()
        {
            CreateMap<CreateFilmeDTO, Filme>();
            CreateMap<UpdateFilmeDTO, Filme>();
            CreateMap<Filme, UpdateFilmeDTO>();
            CreateMap<Filme, ReadFilmeDto>();
        }
    }
}
