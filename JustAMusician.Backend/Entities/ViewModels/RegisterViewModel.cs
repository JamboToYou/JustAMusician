using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JustAMusician.Backend.Entities.ViewModels
{
	public class RegisterViewModel
	{
		[Required]
		public string Nickname { get; set; }

		[Required]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }

		[Required]
		[DataType(DataType.Password)]
		[MinLength(8)]
		public string Password { get; set; }

		[DataType(DataType.Password)]
		[MinLength(8)]
		[Compare("Password")]
		public string PasswordConfirmation { get; set; }

		[DataType(DataType.MultilineText)]
		public string About { get; set; }

		[Required]
		public IEnumerable<string> Links { get; set; }
	}
}