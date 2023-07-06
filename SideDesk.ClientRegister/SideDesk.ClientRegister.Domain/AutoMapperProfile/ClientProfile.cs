using AutoMapper;
using SideDesk.ClientRegister.Application.Entities;
using SideDesk.ClientRegister.Domain.Models.Registry;

namespace SideDesk.ClientRegister.Domain.AutoMapperProfile
{
	public class ClientProfile : Profile
	{
		public ClientProfile() 
		{
			CreateMap<RegistryRest, Client>().ReverseMap();
		}
	}
}
