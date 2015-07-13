using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Apex.Framework.Entities.Models.Users
{
	public class ApplicationUser : IdentityUser
	{
		public string Fullname { get; set; }

		public DateTime? Birthday { get; set; }

		public DateTime? CreatedOn { get; set; }

		public DateTime? ModifiedOn { get; set; }

		public async Task<ClaimsIdentity> GenerateUserIdentityAsync(
			UserManager<ApplicationUser> manager, 
			string authenticationType = DefaultAuthenticationTypes.ApplicationCookie)
		{
			// Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
			var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
			
			// Add custom user claims here
			
			return userIdentity;
		}
	}
}
