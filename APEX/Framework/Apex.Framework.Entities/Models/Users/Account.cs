using System;
using System.Collections.Generic;

namespace Apex.Framework.Entities.Models.Users
{
	public class Account : BaseEntity
	{
		public string Username { get; set; }

		public string Password { get; set; }

		public string Email { get; set; }

		public bool Gender { get; set; }

		public DateTime? Birthday { get; set; }

		public virtual ICollection<Address> Addresses { get; set; }
	}
}
