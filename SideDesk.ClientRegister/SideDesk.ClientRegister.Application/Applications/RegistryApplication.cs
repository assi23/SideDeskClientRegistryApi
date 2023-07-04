using SideDesk.ClientRegister.Application.Entities;
using SideDesk.ClientRegister.Domain.Interfaces.Application;
using SideDesk.ClientRegister.Domain.Interfaces.Repositories;
using SideDesk.ClientRegister.Domain.Models.Registry;
using System.Security.Cryptography;

namespace SideDesk.ClientRegister.Application.Applications
{
	public class RegistryApplication : IRegistryApplication
	{
		private readonly IClientRepository _clientRepository;

		public RegistryApplication(IClientRepository clientRepository)
        {
			_clientRepository = clientRepository;
		}

        public void Registry(RegistryRest rest)
		{
			var entity = new Client()
			{
				Name = rest.Name,
				Document = rest.Document,
			};

			 _clientRepository.Create(entity);
			_clientRepository.SaveChanges();
		}
	}
}
