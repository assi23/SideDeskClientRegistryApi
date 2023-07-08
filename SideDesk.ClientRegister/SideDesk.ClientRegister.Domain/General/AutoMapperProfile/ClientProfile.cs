using AutoMapper;
using SideDesk.ClientRegister.Application.Entities;
using SideDesk.ClientRegister.Domain.Models.Registry.Registry;

namespace SideDesk.ClientRegister.Domain.General.AutoMapperProfile
{
	public class ClientProfile : Profile
    {
        public ClientProfile()
        {
            CreateMap<RegistryRequest, Client>().ReverseMap();
            CreateMap<Client, RegistryResponse>().ReverseMap();
        }
    }
}
