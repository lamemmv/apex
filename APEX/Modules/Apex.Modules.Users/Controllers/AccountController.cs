using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using Apex.Framework.Entities.Models.Users;
using Apex.Modules.Users.Models;
using Apex.Modules.Users.Services;

namespace Apex.Modules.Users.Controllers
{
	public class AccountController : ApiController
	{
		private readonly IAccountService _accountService;

		public AccountController(IAccountService accountService)
		{
			_accountService = accountService;
		}

		public IEnumerable<Account> Filter(string username, bool? isActive)
		{
			return _accountService.Filter(username, isActive);
		}

		public HttpStatusCode Create(AccountCreateViewModel model)
		{
			if (ModelState.IsValid)
			{
				var entity = new Account 
				{ 
					Username = model.Username,
					Password = model.Password
					// ...
				};

				_accountService.Create(entity);
				return HttpStatusCode.OK;
			}

			return HttpStatusCode.BadRequest;
		}
	}
}
