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
				.WriteTo.File(Path.Combine(AppContext.BaseDirectory, $"logs/{DateTime.Now.Date:yyyy-MM-dd}"), rollingInterval: RollingInterval.Day)
				.CreateLogger();
		}
	}
}