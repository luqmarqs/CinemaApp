using AutoMapper;
using CinemaApp.Data.Dtos;
using CinemaApp.Models;

namespace CinemaApp.Profiles
{
    public class CinemaProfile : Profile
    {
        public CinemaProfile()
        {
            CreateMap<CreateCinemaDTO, Cinema>();
            CreateMap<UpdateCinemaDTO, Cinema>();
            CreateMap<Cinema, UpdateCinemaDTO>();
            CreateMap<Cinema, ReadCinemaDTO>();

        }
    }
}
