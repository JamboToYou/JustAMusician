using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace JustAMusician.Backend.Controllers
{
	[EnableCors("AllowCors")]
	[Route("api/user")]
	[Authorize]
	public class UserController : Controller
	{
		[Route("get")]
		[HttpGet]
		public IActionResult Get() {
			return Ok();
		}
	}
}