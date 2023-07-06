using AutoMapper;
using SideDesk.ClientRegister.Application.Entities;
using SideDesk.ClientRegister.Domain.Interfaces.Application;
using SideDesk.ClientRegister.Domain.Interfaces.Repositories;
using SideDesk.ClientRegister.Domain.Models.Registry;

namespace SideDesk.ClientRegister.Application.Applications
{
	public class RegistryApplication : IRegistryApplication
	{
		private readonly IClientRepository _clientRepository;
		private readonly IMapper _mapper;

		public RegistryApplication(IClientRepository clientRepository, IMapper mapper)
		{
			_clientRepository = clientRepository;
			_mapper = mapper;
		}

		public void Registry(RegistryRest rest)
		{
			var entity = _mapper.Map<Client>(rest);

			_clientRepository.Create(entity);
			_clientRepository.SaveChanges();
		}
	}
}
