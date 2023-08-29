using Serilog;
using SideDesk.ClientRegister.Infrastructure.Helpers;

namespace SideDesk.ClientRegister.Api.Configuration
{
	public static class LogConfiguration
	{
		public static IServiceCollection ConfigureLogger(this IServiceCollection services)
		{
			LogConfigurator.CreateLog();
			return services.AddLogging(logginBuilder => logginBuilder.AddSerilog(dispose: true));
		}
	}
}