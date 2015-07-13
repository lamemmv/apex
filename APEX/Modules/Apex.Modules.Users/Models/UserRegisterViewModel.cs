using System;
using System.ComponentModel.DataAnnotations;

namespace Apex.Modules.Users.Models
{
	public class UserRegisterViewModel
	{
		[Required]
		public string Username { get; set; }

		[Required]
		public string Fullname { get; set; }

		[Required]
		[EmailAddress]
		public string Email { get; set; }

		[Required]
		[StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[DataType(DataType.Password)]
		[Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
		public string ConfirmPassword { get; set; }

		public DateTime? Birthday { get; set; }
	}
}
