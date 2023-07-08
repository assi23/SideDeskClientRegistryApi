using AutoMapper;
using SideDesk.ClientRegister.Application.Entities;
using SideDesk.ClientRegister.Domain.General.Result;
using SideDesk.ClientRegister.Domain.Interfaces.Application;
using SideDesk.ClientRegister.Domain.Interfaces.Repositories;
using SideDesk.ClientRegister.Domain.Models.Registry.Registry;

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

		public IResult<RegistryResponse> Registry(RegistryRequest request)
		{
			try
			{
				var client = _mapper.Map<Client>(request);

				_clientRepository.Create(client);
				var save = _clientRepository.SaveChanges();

				if (save <= 0)
					throw new ArgumentException($"Fail to registry client with document {request.Document}, try again later!");

				var response = _mapper.Map<RegistryResponse>(client);

				return Result<RegistryResponse>.CreateSuccess(response);

			}
			catch (Exception ex)
			{
				return Result<RegistryResponse>.CreateFailure(ex.Message);
			}
		}
	}
}
