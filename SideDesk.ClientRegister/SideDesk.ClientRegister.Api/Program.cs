using SideDesk.ClientRegister.Application.Applications;
using SideDesk.ClientRegister.Domain.Interfaces.Application;

namespace SideDesk.ClientRegister;
public class Program
{
	static void Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);
		ConfigureServices(builder.Services);

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

	private static void ConfigureServices(IServiceCollection services)
	{
		services.AddControllers();
		services.AddEndpointsApiExplorer();
		services.AddSwaggerGen();

		ConfigureDependencyInjection(services);
	}

	private static void ConfigureDependencyInjection(IServiceCollection services)
	{
		services.AddScoped<IRegistryApplication, RegisterApplication>();
	}
}