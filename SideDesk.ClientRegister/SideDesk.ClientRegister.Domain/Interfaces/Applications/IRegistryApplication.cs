using SideDesk.ClientRegister.Domain.General.Result;
using SideDesk.ClientRegister.Domain.Models.Registry.Get;
using SideDesk.ClientRegister.Domain.Models.Registry.Registry;

namespace SideDesk.ClientRegister.Domain.Interfaces.Application
{
	public interface IRegistryApplication
	{
		Task<IResult<PostRegistryResponse>> Registry(PostRegistryRequest request);
		Task<IResult<GetRegistryResponse>> GetRegistry(string document);
	}
}
