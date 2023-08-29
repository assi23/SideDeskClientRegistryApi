using SideDesk.ClientRegister.Api.Configuration;

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

		services.ConfigureContext(configuration);
		services.ConfigureAutoMapper();
		services.ConfigureApplication();
		services.ConfigureLogger();
	}
}