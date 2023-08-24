using SideDesk.ClientRegister.Application.Applications;
using SideDesk.ClientRegister.Domain.Interfaces.Application;
using SideDesk.ClientRegister.Domain.Interfaces.Repositories;
using SideDesk.ClientRegister.Infrastructure.Context;
using SideDesk.ClientRegister.Infrastructure.Repository;
using SideDesk.Nugget.Cryptography.Services;

namespace SideDesk.ClientRegister.Api.Configuration
{
	public static class DependencyInjectionConfiguration
	{
		public static IServiceCollection ConfigureContext(this IServiceCollection services, IConfiguration configuration)
			=> services.AddNpgsql<DataContext>(configuration?.GetConnectionString("default")?.Decrypt());

		public static IServiceCollection ConfigureApplication(this IServiceCollection services)
		{
			return services.AddScoped<IRegistryApplication, RegistryApplication>()
						   .AddScoped<IClientRepository, ClientRepository>();
		}
	}
}
