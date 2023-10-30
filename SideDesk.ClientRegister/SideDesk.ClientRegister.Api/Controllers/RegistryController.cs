using Microsoft.AspNetCore.Mvc;
using SideDesk.ClientRegister.Domain.General.Result;
using SideDesk.ClientRegister.Domain.Interfaces.Application;
using SideDesk.ClientRegister.Domain.Models.Registry.Get;
using SideDesk.ClientRegister.Domain.Models.Registry.Registry;

namespace SideDesk.ClientRegister.Api.Controllers
{
	[ApiController, Route("api/[controller]")]
	public class RegistryController : ControllerBase
	{
		private readonly IRegistryApplication _registryApplication;

		public RegistryController(IRegistryApplication registryApplication)
		{
			_registryApplication = registryApplication;
		}

		[HttpPost]
		[ProducesResponseType(typeof(IResult<PostRegistryResponse>), StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(IResult<PostRegistryResponse>), StatusCodes.Status400BadRequest)]
		public async Task<ActionResult<IResult<PostRegistryResponse>>> Registry(PostRegistryRequest request)
		{
			var registry = await _registryApplication.Registry(request);

			if (registry.Success)
				return Ok(registry);

			return BadRequest(registry);
		}

		[HttpGet]
		[ProducesResponseType(typeof(IResult<GetRegistryResponse>), StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(IResult<GetRegistryResponse>),StatusCodes.Status400BadRequest)]
		public async Task<IResult<GetRegistryResponse>> Get(string document)
		{ 
			var registry = await _registryApplication.GetRegistry(document);

			return registry;
		}
	}
}
