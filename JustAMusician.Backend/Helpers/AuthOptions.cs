using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace JustAMusician.Backend.Helpers
{
	public class AuthOptions
	{
		public const string ISSUER = "JAMServer";
		public const string AUDIENCE = "JAMClient";
		const string KEY = "thisisthebestkeyinyourlife!!!666!!!";
		public const int LIFETIME = 1;
		public static SymmetricSecurityKey GetSymmetricSecurityKey()
		{
			return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
		}
	}
}