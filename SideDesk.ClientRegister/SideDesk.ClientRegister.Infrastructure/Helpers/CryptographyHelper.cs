using SideDesk.Nugget.Cryptography.Services;

namespace SideDesk.ClientRegister.Infrastructure.Helpers
{
	public static class CryptographyHelper
	{
		public static string DecryptConnectionString(this string connectionString)
		{
			return new DecryptService().Decrypt(connectionString);
		}
	}
}
