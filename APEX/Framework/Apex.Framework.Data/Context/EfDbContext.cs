using System.Data.Entity;

namespace Apex.Framework.Data.Context
{
	public class EfDbContext : DbContext
	{
		public EfDbContext()
			: base("ApexContext")
		{
		}

		public static EfDbContext Create
		{
			get
			{
				return new EfDbContext();
			}
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
		}
	}
}
