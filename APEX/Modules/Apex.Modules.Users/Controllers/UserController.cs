using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Apex.Modules.Users.Models;
using Apex.Modules.Users.Services;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace Apex.Modules.Users.Controllers
{
	[RoutePrefix("api/user")]
	public class UserController : ApiController
	{
		private IOwinContext _owinContext;
		private IOwinContext OwinContext
		{
			get
			{
				return _owinContext ?? (_owinContext = HttpContext.Current.GetOwinContext());
			}
		}

		private ApplicationUserManager _userManager;
		private ApplicationUserManager UserManager
		{
			get
			{
				return _userManager ?? (_userManager = OwinContext.GetUserManager<ApplicationUserManager>());
			}
		}

		private ApplicationSignInManager _signInManager;
		private ApplicationSignInManager SignInManager
		{
			get
			{
				return _signInManager ?? (_signInManager = OwinContext.GetUserManager<ApplicationSignInManager>());
			}
		}

		[HttpPost]
		[AllowAnonymous]
		[Route("authenticate")]
		public async Task<IHttpActionResult> Authenticate(UserLoginViewModel model)
		{
			if (ModelState.IsValid)
			{
				var applicationUser = await UserManager.FindAsync(model.Username, model.Password);
				if (applicationUser == null)
				{
					UserManager.ResetAccessFailedCount
					return BadRequest("Invalid login attempt.");	
				}
				
				var loginInResult = await SignInManager.PasswordSignInAsync(model.Username, model.Password, false, shouldLockout: true);
				switch (loginInResult)
				{
					case SignInStatus.Success:
						return Ok();

					case SignInStatus.LockedOut:
						ModelState.AddModelError(string.Empty, "Your account was locked.");
						break;

					case SignInStatus.RequiresVerification:
						ModelState.AddModelError(string.Empty, "Your account need to verify.");
						break;

					case SignInStatus.Failure:
					default:
						ModelState.AddModelError(string.Empty, "Invalid login attempt.");
						break;
				}
			}

			return BadRequest(ModelState);
		}

		public IHttpActionResult Logout()
		{
			OwinContext.Authentication.SignOut();
			return Ok();
		}

		//[HttpPost]
		//public async Task<IHttpActionResult> ForgotPassword(UserForgotPasswordViewModel model)
		//{
		//	if (ModelState.IsValid)
		//	{
		//		var user = await UserManager.FindByNameAsync(model.Email);
		//		if (user == null || !(await UserManager.IsEmailConfirmedAsync(user.Id)))
		//		{
		//			// Don't reveal that the user does not exist or is not confirmed
		//			return BadRequest("ForgotPasswordConfirmation");
		//		}

		//		var code = await UserManager.GeneratePasswordResetTokenAsync(user.Id);
		//		//var callbackUrl = Url.Action("ResetPassword", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
		//		//await UserManager.SendEmailAsync(user.Id, "Reset Password", "Please reset your password by clicking here: <a href=\"" + callbackUrl + "\">link</a>");
		//		//ViewBag.Link = callbackUrl;

		//		//return View("ForgotPasswordConfirmation");
		//	}

		//	return BadRequest(ModelState);
		//}

		//[HttpPost]
		//public async Task<IHttpActionResult> Register(UserRegisterViewModel userViewModel)
		//{
		//	if (ModelState.IsValid)
		//	{
		//		var currentTime = DateTime.UtcNow;
		//		var user = new ApplicationUser
		//		{
		//			UserName = userViewModel.Username,
		//			Fullname = userViewModel.Fullname,
		//			Email = userViewModel.Email,
		//			Birthday = userViewModel.Birthday,
		//			CreatedOn = currentTime,
		//			ModifiedOn = currentTime
		//		};

		//		var result = await UserManager.CreateAsync(user, userViewModel.Password);
		//		if (result.Succeeded)
		//		{
		//			var code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);

		//			var callbackUrl = new Uri(Url.Link("ConfirmEmail", new { userId = user.Id, code = code }));
		//			await _userManager.SendEmailAsync(
		//				user.Id, 
		//				"Confirm your account", 
		//				"Please confirm your account by clicking this link: <a href=\"" + callbackUrl + "\">here</a>");

		//			Uri locationHeader = new Uri(Url.Link("GetUserById", new { id = user.Id }));
		//			//return Created(locationHeader, TheModelFactory.Create(user));
		//		}

		//		AddErrorsToModelState(result);
		//	}

		//	return BadRequest(ModelState);
		//}

		private void AddErrorsToModelState(IdentityResult result)
		{
			foreach (var error in result.Errors)
			{
				ModelState.AddModelError(string.Empty, error);
			}
		}
	}
}
