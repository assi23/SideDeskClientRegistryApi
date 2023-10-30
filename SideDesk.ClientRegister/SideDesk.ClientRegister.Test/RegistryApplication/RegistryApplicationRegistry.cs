using AutoFixture;
using AutoMapper;
using Microsoft.Extensions.Logging;
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

		private readonly Mock<IClientRepository> _clientRepositoryMock = new();
		private readonly Mock<IMapper> _mapperMock = new();
		private readonly Mock<ILogger<RegistryApplication>>  _loggerMock = new();

		public RegistryApplicationRegistry()
		{
			_registryApplication = new RegistryApplication(_clientRepositoryMock.Object, _mapperMock.Object, _loggerMock.Object);
		}

		[Fact(DisplayName = "Success")]
		[Trait("Application", "Registry")]
		public async Task Registry_ReturnSuccess()
		{
			//Arrange
			var request = _fixture.Create<PostRegistryRequest>();
			var client = _fixture.Build<Client>().With(a => a.Name, request.Name).With(a => a.Document, request.Document).Create();
			var registryResponse = _fixture.Build<PostRegistryResponse>().With(a => a.Name, client.Name).With(a => a.Document, client.Document).Create();

			_clientRepositoryMock.Setup(a => a.SaveChangesAsync()).ReturnsAsync(1);
			_mapperMock.Setup(a => a.Map<Client>(request)).Returns(client);
			_mapperMock.Setup(a => a.Map<PostRegistryResponse>(client)).Returns(registryResponse);

			//Act
			var response = await _registryApplication.Registry(request);

			//Assert
			Assert.True(response.Success);
			Assert.Equal(response.Model, registryResponse);
		}

		[Fact(DisplayName = "Failure")]
		[Trait("Application", "Registry")]
		public async Task Registry_ReturnFalse()
		{
			//Arrange
			var request = _fixture.Build<PostRegistryRequest>().With(a=> a.Name,"Test").With(a=> a.Document, "123.123.123-12").Create();
			var client = _fixture.Build<Client>().With(a => a.Name, request.Name).With(a => a.Document, request.Document).Create();
			var registryResponse = _fixture.Build<PostRegistryResponse>().With(a => a.Name, client.Name).With(a => a.Document, client.Document).Create();

			_clientRepositoryMock.Setup(a => a.SaveChangesAsync()).ReturnsAsync(0);
			_mapperMock.Setup(a => a.Map<Client>(request)).Returns(client);
			_mapperMock.Setup(a => a.Map<PostRegistryResponse>(client)).Returns(registryResponse);

			//Act
			var response = await _registryApplication.Registry(request);

			//Assert
			Assert.False(response.Success);
			Assert.Equal("An internal error occurred, try again later!", response.Messages.First());
		}

		//TODO test specified NullReferenceException
	}
}
