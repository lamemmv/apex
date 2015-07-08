using System;
using System.Collections.Generic;
using Apex.Framework.Data.Context;
using Apex.Framework.Entities.Models.Users;
using Apex.Modules.Users.Repositories;

namespace Apex.Modules.Users.Services
{
	public class AccountService : IAccountService
	{
		private readonly IUnitOfWork _unitOfWork;

		public AccountService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public IEnumerable<Account> Filter(string username, bool? isActive)
		{
			return _unitOfWork.Repository<Account>().Filter(username, isActive);
		}

		public void Create(Account entity)
		{
			entity.Birthday = DateTime.UtcNow;
			try
			{
				_unitOfWork.Repository<Account>().Insert(entity);
				_unitOfWork.Commit();
			}
			catch (Exception)
			{
				_unitOfWork.Rollback();
				throw;
			}
		}
	}
}
