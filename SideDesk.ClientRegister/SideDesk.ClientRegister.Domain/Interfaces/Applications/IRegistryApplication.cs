using Microsoft.Win32;
using SideDesk.ClientRegister.Domain.Models.Registry;

namespace SideDesk.ClientRegister.Domain.Interfaces.Application
{
	public interface IRegistryApplication
	{
		void Registry(RegistryRest rest);
	}
}
