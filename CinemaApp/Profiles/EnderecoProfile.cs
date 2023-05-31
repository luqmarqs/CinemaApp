using AutoMapper;
using CinemaApp.Data.Dtos;
using CinemaApp.Models;

namespace CinemaApp.Profiles
{
    public class EnderecoProfile : Profile
    {
        public EnderecoProfile()
        {
            CreateMap<CreateEnderecoDTO, Endereco>();
            CreateMap<UpdateEnderecoDTO, Endereco>();
            CreateMap<Endereco, UpdateEnderecoDTO>();
            CreateMap<Endereco, ReadEnderecoDTO>();

        }
    }
}
