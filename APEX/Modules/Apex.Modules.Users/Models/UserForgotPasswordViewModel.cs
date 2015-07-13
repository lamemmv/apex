using System.ComponentModel.DataAnnotations;

namespace Apex.Modules.Users.Models
{
	public class UserForgotPasswordViewModel
	{
		[Required]
		[EmailAddress]
		public string Email { get; set; }
	}
}
