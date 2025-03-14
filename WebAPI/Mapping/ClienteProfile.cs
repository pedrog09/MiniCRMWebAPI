using AutoMapper;
using WebAPI.DTOs;
using WebAPI.Models;

namespace WebAPI.Mapping
{
    public class ClienteProfile : Profile
    {
        public ClienteProfile()
        {
            CreateMap<ClienteModel, ClienteDto>();
            CreateMap<ClienteDto, ClienteModel>();
        }
    }
}
