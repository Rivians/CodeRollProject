﻿using CodeRollProject.BusinessLayer.Concrete;
using CodeRollProject.DataAccessLayer.EntityFramework;
using CodeRollProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using CodeRollProject.BusinessLayer.ValidationRules;
using CodeRollProject.BusinessLayer.Abstract;

namespace CodeRollProject.PresentationLayer.Controllers
{
	[AllowAnonymous]
	public class RegisterController : Controller
	{
		private readonly IUserService um;
        public RegisterController(IUserService userManager)
        {
            um = userManager;
        }

        UserRegisterValidator urv = new UserRegisterValidator();


        [HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Index(User user)
		{
            ValidationResult result = urv.Validate(user);

            if (result.IsValid)
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
