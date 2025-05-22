using AutoMapper;
using WebAPI.DTOs;
using WebAPI.Models;

namespace WebAPI.Mapping
{
    public class ClientProfile : Profile
    {
        public ClientProfile()
        {
            CreateMap<ClientModel, ClientDto>();
            CreateMap<ClientDto, ClientModel>();
        }
    }
}
