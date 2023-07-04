using SideDesk.ClientRegister.Application.Applications;
using SideDesk.ClientRegister.Domain.Interfaces.Application;
using SideDesk.ClientRegister.Domain.Interfaces.Repositories;
using SideDesk.ClientRegister.Infrastructure.Context;
using SideDesk.ClientRegister.Infrastructure.Helpers;
using SideDesk.ClientRegister.Infrastructure.Repository;

namespace SideDesk.ClientRegister;
public class Program
{
	static void Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);
		ConfigureServices(builder.Services, builder.Configuration);

		var app = builder.Build();

		if (app.Environment.IsDevelopment())
		{
			app.UseSwagger();
			app.UseSwaggerUI();
		}

		app.UseAuthorization();

		app.MapControllers();

		app.Run();
	}

	private static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
	{
		services.AddControllers();
		services.AddEndpointsApiExplorer();
		services.AddSwaggerGen();
		services.AddNpgsql<DataContext>(configuration.GetConnectionString("default").DecryptConnectionString());

		ConfigureDependencyInjection(services);
	}

	private static void ConfigureDependencyInjection(IServiceCollection services)
	{
		services.AddScoped<IRegistryApplication, RegistryApplication>();
		services.AddScoped<IClientRepository, ClientRepository>();
	}
}