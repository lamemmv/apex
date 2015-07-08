using System.Collections.Generic;

namespace Apex.Framework.Entities.Models.Users
{
	public class Address : BaseEntity
	{
		public string Street { get; set; }

		public string District { get; set; }

		public string City { get; set; }

		public string ZipCode { get; set; }

		public int? AccountId { get; set; }
		public virtual Account Account { get; set; }
	}
}
