using SideDesk.ClientRegister.Domain.General.Result;
using SideDesk.ClientRegister.Domain.Models.Registry.Registry;

namespace SideDesk.ClientRegister.Domain.Interfaces.Application
{
	public interface IRegistryApplication
	{
		IResult<RegistryResponse> Registry(RegistryRequest request);
	}
}
