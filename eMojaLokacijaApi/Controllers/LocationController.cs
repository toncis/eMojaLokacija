using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eMojaLokacijaApi.Controllers
{
	[ApiVersion("1")]
	[Produces("application/json")]
	[Authorize]
	public class LocationController : Controller
	{
		private readonly ILogger<LocationController> _logger;

		public LocationController(ILogger<LocationController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
			return View();
		}
	}
}
