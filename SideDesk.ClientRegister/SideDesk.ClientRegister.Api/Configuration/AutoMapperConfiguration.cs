using SideDesk.ClientRegister.Domain.General.AutoMapperProfile;

namespace SideDesk.ClientRegister.Api.Configuration
{
	public static class AutoMapperConfiguration
	{
		public static IServiceCollection ConfigureAutoMapper(this IServiceCollection services)
		{
			return services.AddAutoMapper(typeof(ClientProfile)); ;
		}
	}
}
