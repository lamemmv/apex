using System;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using Apex.Framework.Data.Repositories;
using Apex.Framework.Entities;

namespace Apex.Framework.Data.Context
{
	public class UnitOfWork : IUnitOfWork, IDisposable
	{
		protected readonly DbContext _context;
		private readonly ObjectContext _objectContext;
		private readonly IDbTransaction _transaction;
		private bool _disposed;

		public UnitOfWork(DbContext context = null)
		{
			_context = context ?? EfDbContext.Create;
			_context.Configuration.ValidateOnSaveEnabled = false;

			_objectContext = ((IObjectContextAdapter)_context).ObjectContext;
			if (_objectContext.Connection.State != ConnectionState.Open)
			{
				_objectContext.Connection.Open();
				_transaction = _objectContext.Connection.BeginTransaction();
			}
		}

		public async void Commit()
		{
			await _context.SaveChangesAsync();
			_transaction.Commit();
		}

		public void Rollback()
		{
			_transaction.Rollback();
			var entries = _context.ChangeTracker.Entries();
			foreach (var entry in entries)
			{
				switch (entry.State)
				{
					case EntityState.Modified:
						entry.State = EntityState.Unchanged;
						break;

					case EntityState.Added:
						entry.State = EntityState.Detached;
						break;

					case EntityState.Deleted:
						entry.State = EntityState.Unchanged;
						break;

					default:
						break;
				}
			}
		}

		protected void Dispose(bool disposing)
		{
			if (_disposed)
			{
				return;
			}

			if (disposing)
			{
				// free other managed objects that implement
				// IDisposable only
				try
				{
					if (_objectContext != null && _objectContext.Connection.State == ConnectionState.Open)
					{
						_objectContext.Connection.Close();
					}
				}
				catch (ObjectDisposedException)
				{
					// do nothing, the objectContext has already been disposed
				}

				if (_context != null)
				{
					_context.Dispose();
				}
			}

			// release any unmanaged objects
			// set the object references to null
			_disposed = true;
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		public IRepository<T> Repository<T>() where T : BaseEntity
		{
			var repositoryType = typeof(EfRepository<>);
			return (IRepository<T>)Activator.CreateInstance(
				repositoryType.MakeGenericType(typeof(T)), 
				_context);
		}
	}
}
