using System.Collections.Generic;
using Apex.Framework.Entities.Models.Users;

namespace Apex.Modules.Users.Services
{
	public interface IAccountService
	{
		IEnumerable<Account> Filter(string username, bool? isActive);

		void Create(Account entity);
	}
}
