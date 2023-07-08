using Microsoft.AspNetCore.Mvc;
using SideDesk.ClientRegister.Domain.General.Result;
using SideDesk.ClientRegister.Domain.Interfaces.Application;
using SideDesk.ClientRegister.Domain.Models.Registry.Registry;

namespace SideDesk.ClientRegister.Api.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class RegistryController : ControllerBase
	{
		private readonly IRegistryApplication _registryApplication;

		public RegistryController(IRegistryApplication registryApplication)
		{
			_registryApplication = registryApplication;
		}

		[HttpPost]
		[ProducesResponseType(typeof(IResult<RegistryResponse>), StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(IResult<RegistryResponse>), StatusCodes.Status400BadRequest)]
		public ActionResult<IResult<RegistryResponse>> Registry(RegistryRequest request)
		{
			var registry =  _registryApplication.Registry(request);

			if (registry.Success)
				return Ok(registry);

			return BadRequest(registry);
		}
	}
}
