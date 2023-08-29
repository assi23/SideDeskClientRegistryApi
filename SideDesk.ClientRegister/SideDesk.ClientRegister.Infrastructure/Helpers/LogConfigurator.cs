using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;

namespace SideDesk.ClientRegister.Infrastructure.Helpers
{
	public  class LogConfigurator
	{
		public static void CreateLog()
		{
			Log.Logger = new LoggerConfiguration()
				.MinimumLevel.Information()
				.MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
				.MinimumLevel.Override("Microsoft.Hosting.Lifetime", LogEventLevel.Information)
				.WriteTo.File($"logs/.txt", rollingInterval: RollingInterval.Day)
				.CreateLogger();
		}
	}
}