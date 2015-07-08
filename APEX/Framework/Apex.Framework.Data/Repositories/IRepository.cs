using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Apex.Framework.Core.Pagination;
using Apex.Framework.Entities;

namespace Apex.Framework.Data.Repositories
{
	public interface IRepository<T> where T : BaseEntity
	{
		T FindBy(object id, Expression<Func<T, object>>[] includes = null);
		T FindBy(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);
		IEnumerable<T> FindBy(
			Expression<Func<T, bool>> predicate = null,
			Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
			params Expression<Func<T, object>>[] includes);
		PagedList<T> FindBy(
			Expression<Func<T, bool>> predicate = null,
			Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
			int pageIndex = 1,
			int pageSize = 20,
			params Expression<Func<T, object>>[] includes);

		void Insert(T entity);
		void Update(T entity);
		void Delete(T entity);
		void Delete(object id);
	}
}
