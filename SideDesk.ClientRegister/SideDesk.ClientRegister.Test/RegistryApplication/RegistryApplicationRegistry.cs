using AutoFixture;
using AutoMapper;
using Moq;
using SideDesk.ClientRegister.Application.Applications;
using SideDesk.ClientRegister.Application.Entities;
using SideDesk.ClientRegister.Domain.Interfaces.Repositories;
using SideDesk.ClientRegister.Domain.Models.Registry.Registry;
using Xunit;

namespace SideDesk.ClientRegister.Test
{
	public class RegistryApplicationRegistry
	{
		private readonly RegistryApplication _registryApplication;
		private readonly Fixture _fixture = new();

		private readonly Mock<IClientRepository> _clientRepository = new();
		private readonly Mock<IMapper> _mapper = new();

		public RegistryApplicationRegistry()
		{
			_registryApplication = new RegistryApplication(_clientRepository.Object, _mapper.Object);
		}

		[Fact(DisplayName = "Success")]
		[Trait("Application", "Registry")]
		public void Registry_ReturnSuccess() 
		{
			//Arrange
			var request = _fixture.Create<RegistryRequest>();
			var client = _fixture.Build<Client>().With(a => a.Name, request.Name).With(a=> a.Document, request.Document).Create();
			var registryResponse = _fixture.Build<RegistryResponse>().With(a => a.Name, client.Name).With(a => a.Document, client.Document).Create();

			_clientRepository.Setup(a => a.SaveChanges()).Returns(1);
			_mapper.Setup(a => a.Map<Client>(request)).Returns(client);
			_mapper.Setup(a => a.Map<RegistryResponse>(client)).Returns(registryResponse);

			//Act
			var response = _registryApplication.Registry(request);

			//Assert
			Assert.True(response.Success);
			Assert.Equal(response.Model, registryResponse);
		}
	}
}
