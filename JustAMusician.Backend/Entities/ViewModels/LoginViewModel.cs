using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JustAMusician.Backend.Entities.ViewModels
{
	public class LoginViewModel
	{
		[Required]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }

		[Required]
		[DataType(DataType.Password)]
		[MinLength(8)]
		public string Password { get; set; }
	}
}