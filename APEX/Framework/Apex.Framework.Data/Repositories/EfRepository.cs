using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Apex.Framework.Core.Pagination;
using Apex.Framework.Entities;

namespace Apex.Framework.Data.Repositories
{
	public abstract class EfRepository<T> : IRepository<T> where T : BaseEntity
	{
		private readonly DbContext _context;

		public EfRepository(DbContext context)
		{
			_context = context;
		}

		private IDbSet<T> CreateSet(IEnumerable<Expression<Func<T, object>>> includes = null)
		{
			IDbSet<T> dbset = _context.Set<T>();
			if (includes != null)
			{
				foreach (var include in includes)
				{
					dbset.Include(include);
				}
			}

			return dbset;
		}

		public virtual T FindBy(object id, params Expression<Func<T, object>>[] includes)
		{
			return CreateSet(includes).Find(id);
		}

		public virtual T FindBy(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
		{
			return CreateSet(includes).Where(predicate).FirstOrDefault();
		}

		public virtual IEnumerable<T> FindBy(
			Expression<Func<T, bool>> predicate = null, 
			Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
			params Expression<Func<T, object>>[] includes)
		{
			return GetMany(predicate, orderBy, includes).AsEnumerable();
		}

		public virtual PagedList<T> FindBy(
			Expression<Func<T, bool>> predicate = null,
			Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
			int pageIndex = 1,
			int pageSize = 20,
			params Expression<Func<T, object>>[] includes)
		{
			return new PagedList<T>(GetMany(predicate, orderBy, includes), pageIndex, pageSize);
		}

		public virtual void Insert(T entity)
		{
			CreateSet().Add(entity);
		}

		public virtual void Update(T entity)
		{
			CreateSet().Attach(entity);
			_context.Entry(entity).State = EntityState.Modified;
		}

		public virtual void Delete(T entity)
		{
			CreateSet().Remove(entity);
		}

		public virtual void Delete(object id)
		{
			T entity = FindBy(id);
			if (entity != null)
			{
				Delete(entity);
			}
		}

		private IQueryable<T> GetMany(
			Expression<Func<T, bool>> predicate = null,
			Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
			params Expression<Func<T, object>>[] includes)
		{
 			var query = CreateSet(includes).AsNoTracking();
			if (predicate != null)
			{
				query = query.Where(predicate);
			}

			if (orderBy != null)
			{
				query = orderBy(query);
			}

			return query;
		}
	}
}
