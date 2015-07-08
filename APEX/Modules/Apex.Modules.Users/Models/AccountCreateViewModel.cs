using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Apex.Framework.Entities.Models.Users;

namespace Apex.Modules.Users.Models
{
	public class AccountCreateViewModel
	{
		[Required]
		public string Username { get; set; }

		[Required]
		public string Password { get; set; }

		[Required]
		[EmailAddress]
		public string Email { get; set; }

		public bool Gender { get; set; }

		public DateTime? Birthday { get; set; }

		public virtual IList<Address> Addresses { get; set; }
	}
}
