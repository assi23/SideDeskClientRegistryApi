using Microsoft.AspNetCore.Mvc;
using SideDesk.ClientRegister.Domain.Interfaces.Application;

namespace SideDesk.ClientRegister.Api.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class RegistryController : Controller
	{
		private readonly IRegistryApplication _registryApplication;

		public RegistryController(IRegistryApplication registryApplication) 
		{
			_registryApplication = registryApplication;
		}

		[HttpGet]
		public IActionResult Index()
		{
			_registryApplication.Registry();
			return View();
		}
	}
}
