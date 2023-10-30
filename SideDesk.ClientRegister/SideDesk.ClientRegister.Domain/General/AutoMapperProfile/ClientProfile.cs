using AutoMapper;
using SideDesk.ClientRegister.Application.Entities;
using SideDesk.ClientRegister.Domain.Models.Registry.Get;
using SideDesk.ClientRegister.Domain.Models.Registry.Registry;

namespace SideDesk.ClientRegister.Domain.General.AutoMapperProfile
{
	public class ClientProfile : Profile
    {
        public ClientProfile()
        {
            CreateMap<PostRegistryRequest, Client>().ReverseMap();
            CreateMap<Client, PostRegistryResponse>().ReverseMap();

			CreateMap<Client, GetRegistryResponse>().ReverseMap();
		}
    }
}
