using System;
using System.Collections.Generic;
using System.Linq;
using Apex.Framework.Data.Repositories;
using Apex.Framework.Entities.Models.Users;

namespace Apex.Modules.Users.Repositories
{
	public static class AccountRepository
	{
		public static IEnumerable<Account> Filter(
			this IRepository<Account> accountRepository,
			string username,
			bool? isActive)
		{
			return accountRepository.FindBy(
				predicate: a => a.Username.Equals(username, StringComparison.OrdinalIgnoreCase),
				orderBy: o => o.OrderBy(a => a.Username),
				includes: i => i.Addresses);
		}
	}
}
