using AutoMapper;
using CoVoyageur.API.DTOs;
using CoVoyageur.Core.Models;

namespace CoVoyageur.API.Helpers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<User, UserDTO>().ReverseMap();
        }
    }
}