using System;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace JustAMusician.Backend.Helpers
{
	public static class PasswordManager
	{
		public static string HashWithSalt(string password, out byte[] salt)
		{
			salt = GenerateSalt();
			return HashPassword(password, salt);
		}

		public static bool ValidatePassword(string password, string hash, byte[] salt)
			=> HashPassword(password, salt) == hash;

		public static string HashPassword(string password, byte[] salt)
		{
			// derive a 256-bit subkey (use HMACSHA1 with 10,000 iterations)
			string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
				password: password,
				salt: salt,
				prf: KeyDerivationPrf.HMACSHA1,
				iterationCount: 10000,
				numBytesRequested: 256 / 8));

			return hashed;
		}

		public static byte[] GenerateSalt()
		{
			var salt = new byte[128 / 8];
			using (var rng = RandomNumberGenerator.Create())
			{
				rng.GetBytes(salt);
			}
			return salt;
		}
	}
}