using CodeRollProject.BusinessLayer.ValidationRules;
using CodeRollProject.DataAccessLayer.Concrete;
using CodeRollProject.EntityLayer.Concrete;
using FluentValidation.Results;
using Humanizer;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CodeRollProject.PresentationLayer.Controllers
{
	[AllowAnonymous]
	public class LoginController : Controller
	{
        UserLoginValidator ulv = new UserLoginValidator();

        [HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Index(User user)
		{
			Context c = new Context();
			
			ValidationResult result = ulv.Validate(user);

			var data = c.Users.FirstOrDefault(x => x.Email == user.Email && x.Password == user.Password);
					
			if(data != null && result.IsValid)
			{
				ViewData["User"] = user;
                var claims = new List<Claim>
				{
                    new Claim(ClaimTypes.Email, user.Email)															
				};

				var userIdentity = new ClaimsIdentity(claims, "a");   
				ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
				await HttpContext.SignInAsync(principal);

				return RedirectToAction("Index","Dashboard");
			}
			else
			{
				foreach (var item in result.Errors)
				{
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
			}		
		}
	}
}
