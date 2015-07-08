using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Apex.Framework.Entities.Models.Users;

namespace Apex.Framework.Entities.Mapping.Users
{
	public class AccountMap : EntityTypeConfiguration<Account>
	{
		public AccountMap()
		{
			// Primary Key.
			this.HasKey(k => k.Id);

			// Table & Column Mappings.
			this.ToTable("Accounts");
			this.Property(p => p.Username)
				.IsRequired()
				.HasMaxLength(1024);

			this.Property(p => p.Password)
				.IsRequired()
				.HasMaxLength(1024);

			this.Property(p => p.Email)
				.IsRequired()
				.HasMaxLength(1024);

			// Relationships.
			//this.HasRequired<NewsCategory>(a => a.NewsCategory)
			//	.WithMany(c => c.Articles)
			//	.HasForeignKey(n => n.NewsCategoryId);
		}
	}
}
