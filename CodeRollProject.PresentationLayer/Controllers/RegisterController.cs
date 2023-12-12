using CodeRollProject.BusinessLayer.Concrete;
using CodeRollProject.DataAccessLayer.EntityFramework;
using CodeRollProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using CodeRollProject.BusinessLayer.ValidationRules;

namespace CodeRollProject.PresentationLayer.Controllers
{
	[AllowAnonymous]
	public class RegisterController : Controller
	{
		UserManager um = new UserManager(new EfUserRepository());

		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Index(User user)
		{
			UserRegisterValidator urv = new UserRegisterValidator();
			ValidationResult result = urv.Validate(user);

			if(result.IsValid)
			{
				um.TInsert(user);
				return RedirectToAction("Index", "Login");
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
