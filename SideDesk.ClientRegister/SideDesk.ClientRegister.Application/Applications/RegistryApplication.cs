using AutoMapper;
using Microsoft.Extensions.Logging;
using SideDesk.ClientRegister.Application.Entities;
using SideDesk.ClientRegister.Domain.General.Result;
using SideDesk.ClientRegister.Domain.Interfaces.Application;
using SideDesk.ClientRegister.Domain.Interfaces.Repositories;
using SideDesk.ClientRegister.Domain.Models.Registry.Get;
using SideDesk.ClientRegister.Domain.Models.Registry.Registry;
using SideDesk.ClientRegister.Infrastructure.Exceptions.Registry;

namespace SideDesk.ClientRegister.Application.Applications
{
	public class RegistryApplication : IRegistryApplication
	{
		private readonly IClientRepository _clientRepository;
		private readonly IMapper _mapper;
		private readonly ILogger<RegistryApplication> _logger;

		public RegistryApplication(IClientRepository clientRepository, IMapper mapper, ILogger<RegistryApplication> logger)
		{
			_clientRepository = clientRepository;
			_mapper = mapper;
			_logger = logger;
		}

		public async Task<IResult<PostRegistryResponse>> Registry(PostRegistryRequest request)
		{
			try
			{
				_logger.LogInformation("Registering client with document {document}", request.Document);
				var client = _mapper.Map<Client>(request);

				await _clientRepository.CreateAsync(client);
				var save = await _clientRepository.SaveChangesAsync();

				if (save <= 0)
					throw new ArgumentException($"Fail to registry client with document {request.Document}, try again later!");

				var response = _mapper.Map<PostRegistryResponse>(client);

				return Result<PostRegistryResponse>.CreateSuccess(response);
			}
			catch (Exception ex)
			{
				_logger.LogError(string.Concat(ex.Message, "cause:", ex.InnerException));
				return Result<PostRegistryResponse>.CreateFailure("An internal error occurred, try again later!");
			}
		}

		public async Task<IResult<GetRegistryResponse>> GetRegistry(string document) 
		{
			try
			{
				_logger.LogInformation("Trying to get client with document {document}", document);

				var client = await _clientRepository.GetClientByDocumentAsync(document)
					?? throw new GetRegistryException(string.Concat("It's not possible to find a client with the follow document: ", document));

				var clientResponse = _mapper.Map<GetRegistryResponse>(client);

				return Result<GetRegistryResponse>.CreateSuccess(clientResponse);
			}
			catch (GetRegistryException ex)
			{
				_logger.LogError(string.Concat(ex.Message, "cause:", ex.InnerException));
				return Result<GetRegistryResponse>.CreateFailure(ex.Message);
			}
			catch (Exception ex)
			{
				_logger.LogError(string.Concat(ex.Message, "cause:", ex.InnerException));
				return Result<GetRegistryResponse>.CreateFailure("An internal error occurred, try again later!");
			}
		}

	}
}
