using System.Collections.Generic;
using Apex.Framework.Entities.Models.Users;

namespace Apex.Framework.Data.Repositories
{
	public interface IAccountRepository : IRepository<Account>
	{
		IEnumerable<Account> Filter(string username, bool? isActive);
	}
}
