using CodeRollProject.DataAccessLayer.Concrete;
using CodeRollProject.EntityLayer.Concrete;
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
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Index(User user)
		{
			Context c = new Context();
			var data = c.Users.FirstOrDefault(x => x.Email == user.Email && x.Password == user.Password);
					
			if(data != null)
			{
				ViewData["User"] = user;
                var claims = new List<Claim>
				{
					//new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.Email, user.Email)
					
					//  new Claim(ClaimTypes.Name, user.name)  neden olmuyor ?
					//	new Claim(ClaimTypes.Name,"semih yazar"),																				
				};

				var userIdentity = new ClaimsIdentity(claims, "a");   
				ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
				await HttpContext.SignInAsync(principal);

				return RedirectToAction("Index","Dashboard");
			}
			else
			{
				return View();
			}		
		}
	}
}
