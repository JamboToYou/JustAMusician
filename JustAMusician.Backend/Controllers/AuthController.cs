using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using JustAMusician.Backend.Entities;
using JustAMusician.Backend.Entities.Enums;
using JustAMusician.Backend.Entities.ViewModels;
using JustAMusician.Backend.Helpers;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace JustAMusician.Backend.Controllers
{
	[EnableCors("AllowCors")]
	[Route("api/auth")]
	public class AuthController : Controller
	{
		private readonly DataBaseContext dbContext;

		public AuthController(DataBaseContext db)
		{
			dbContext = db;
		}

		[Route("signup")]
		[HttpPost]
		public IActionResult SignUp([FromBody] RegisterViewModel vModel)
		{
			var errors = new Dictionary<string, string>();

			if (dbContext.Users.Any(usr => usr.Email == vModel.Email))
				errors.Add("email", "Профиль с таким адресом уже существует!");

			if (dbContext.Users.Any(usr => usr.Nickname == vModel.Nickname))
				errors.Add("nickname", "Профиль с таким никнеймом уже существует!");

			if (vModel.Password.Length < 8)
				errors.Add("password", "Минимальная длина пароля - 8 символов!");

			if (errors.Count > 0)
				return BadRequest(errors);

			byte[] salt = default(byte[]);
			var hash = PasswordManager.HashWithSalt(vModel.Password, out salt);

			var user = new User
			{
				Nickname = vModel.Nickname,
				Email = vModel.Email,
				About = vModel.About,
				PasswordHash = hash,
				Salt = salt,
				SignedUpAt = DateTime.Now,
				Role = Roles.USER
			};
			dbContext.Users.Add(user);
			dbContext.SaveChanges();

			return Ok();
		}

		[Route("token")]
		[HttpPost]
		public IActionResult Token([FromBody] LoginViewModel vModel)
		{
			var identity = GetIdentity(vModel.Email, vModel.Password);
			if (identity == null)
			{
				return BadRequest(new { error = "Invalid email or password." });
			}

			var now = DateTime.UtcNow;
			// создаем JWT-токен
			var jwt = new JwtSecurityToken(
					issuer: AuthOptions.ISSUER,
					audience: AuthOptions.AUDIENCE,
					notBefore: now,
					claims: identity.Claims,
					expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
					signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
			var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

			var response = new
			{
				access_token = encodedJwt,
				username = identity.Name
			};

			return Json(response);
		}

		private ClaimsIdentity GetIdentity(string email, string password)
		{
			User user = dbContext.Users.FirstOrDefault(x => x.Email == email);

			if (user != null && PasswordManager.ValidatePassword(password, user.PasswordHash, user.Salt))
			{
				var claims = new List<Claim>
				{
					new Claim(ClaimsIdentity.DefaultNameClaimType, user.Nickname),
					new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role.ToString())
				};
				ClaimsIdentity claimsIdentity =
				new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
					ClaimsIdentity.DefaultNameClaimType);
				return claimsIdentity;
			}

			// если пользователя не найдено
			return null;
		}
	}
}