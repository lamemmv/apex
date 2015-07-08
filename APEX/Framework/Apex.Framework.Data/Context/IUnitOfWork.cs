using System;
using Apex.Framework.Data.Repositories;
using Apex.Framework.Entities;

namespace Apex.Framework.Data.Context
{
	public interface IUnitOfWork : IDisposable
	{
		void Commit();
		void Rollback();

		IRepository<T> Repository<T>() where T : BaseEntity;
	}
}
