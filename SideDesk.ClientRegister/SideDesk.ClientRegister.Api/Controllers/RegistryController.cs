using Microsoft.AspNetCore.Mvc;
using SideDesk.ClientRegister.Domain.Interfaces.Application;
using SideDesk.ClientRegister.Domain.Models.Registry;
using SideDesk.ClientRegister.Infrastructure.Helpers;

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
		public IActionResult Registry(RegistryRest rest)
		{
			_registryApplication.Registry(rest);
			return Ok();
		}
	}
}
