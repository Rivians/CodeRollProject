using CodeRollProject.BusinessLayer.ValidationRules;
using CodeRollProject.DataAccessLayer.Concrete;
using CodeRollProject.EntityLayer.Concrete;
using FluentValidation.Results;
using Humanizer;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

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

        //static string Sha256Convertor(string rawData)
        //{
        //    using (SHA256 sha256Hash = SHA256.Create())
        //    {
        //        byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
        //        StringBuilder builder = new StringBuilder();
        //        for (int i = 0; i < bytes.Length; i++)
        //        {
        //            builder.Append(bytes[i].ToString("x2"));
        //        }
        //        return builder.ToString();

        //    }
        //}
    }
}
