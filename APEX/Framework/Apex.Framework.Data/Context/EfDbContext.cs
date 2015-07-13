using System.Data.Entity;
using Apex.Framework.Entities.Models.Users;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Apex.Framework.Data.Context
{
	public class EfDbContext : IdentityDbContext<ApplicationUser>
	{
		public EfDbContext()
			: base("ApexContext", throwIfV1Schema: false)
		{
		}

		public static EfDbContext Create()
		{
			return new EfDbContext();
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
		}
	}
}
