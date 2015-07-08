using System.Data.Entity.ModelConfiguration;
using Apex.Framework.Entities.Models.Users;

namespace Apex.Framework.Entities.Mapping.Users
{
	public class AddressMap : EntityTypeConfiguration<Address>
	{
		public AddressMap()
		{
			// Primary Key.
			this.HasKey(k => k.Id);

			// Table & Column Mappings.
			this.ToTable("Addresses");
		}
	}
}
