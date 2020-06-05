using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;

namespace JustAMusician.Backend.Controllers
{
	[EnableCors("AllowCors")]
	[Route("api/test")]
	public class TestController : Controller
	{
		[Authorize]
		[Route("getlogin")]
		[HttpGet]
		public IActionResult GetLogin()
		{
			return Ok($"Ваш логин: {User.Identity.Name}");
		}

		[Authorize(Roles = "admin")]
		[Route("getrole")]
		[HttpGet]
		public IActionResult GetRole()
		{
			return Ok("Ваша роль: администратор");
		}
	}
}