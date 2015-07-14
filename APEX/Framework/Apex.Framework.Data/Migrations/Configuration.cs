namespace Apex.Framework.Data.Migrations
{
	using System;
	using System.Data.Entity.Migrations;
	using System.Linq;
	using Apex.Framework.Core.Enums;
	using Apex.Framework.Core.Securities;
	using Apex.Framework.Data.Context;
	using Apex.Framework.Entities.Models.Users;
	using Microsoft.AspNet.Identity;
	using Microsoft.AspNet.Identity.EntityFramework;

    internal sealed class Configuration : DbMigrationsConfiguration<Apex.Framework.Data.Context.EfDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Apex.Framework.Data.Context.EfDbContext context)
        {
			RolesAndAccounts();
        }

		private void RolesAndAccounts()
		{
			var currentTime = DateTime.UtcNow;
			var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(EfDbContext.Create()));
			var roleManager = new RoleManager<ApplicationRole>(new RoleStore<ApplicationRole>(EfDbContext.Create()));

			var user = new ApplicationUser()
			{
				UserName = "sa",
				Fullname = "Super Administrator",
				Email = "sa@yahoo.com",
				EmailConfirmed = true,
				CreatedOn = currentTime,
				LockoutEnabled = true,
				PasswordHash = Encryption.ComputeHash(HashProvider.SHA512, "123456", 12)
			};

			userManager.Create(user);

			if (roleManager.Roles.Count() == 0)
			{
				roleManager.Create(new ApplicationRole("Administrator", "Administrator"));
				roleManager.Create(new ApplicationRole("Moderator", "Moderator"));
				roleManager.Create(new ApplicationRole("Registered", "Registered"));
				roleManager.Create(new ApplicationRole("Guests", "Guests"));
			}

			var saUser = userManager.FindByName("sa");
			userManager.AddToRoles(saUser.Id, new string[] { "Administrator", "Moderator", "Registered" });
		}
    }
}
