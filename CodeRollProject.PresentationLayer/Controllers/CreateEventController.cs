﻿using CodeRollProject.BusinessLayer.Abstract;
using CodeRollProject.BusinessLayer.Concrete;
using CodeRollProject.BusinessLayer.ValidationRules;
using CodeRollProject.DataAccessLayer.Concrete;
using CodeRollProject.DataAccessLayer.EntityFramework;
//using CodeRollProject.DtoLayer.Dtos.CreateEventDto;
using CodeRollProject.EntityLayer.Concrete;
using CodeRollProject.PresentationLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Text.Json.Serialization;

namespace CodeRollProject.PresentationLayer.Controllers
{
    [Authorize]
    public class CreateEventController : Controller
    {
        private readonly IEventService em;
        private readonly IUserService um;
        public CreateEventController(IEventService eventManager, IUserService userManager)
        {
            em = eventManager;
            um = userManager;
        }

        UserEventViewModel viewModel = new UserEventViewModel();            // normalde bu kısımlarında Dependecy Injection ile enjekte edilmesi gerekiyor. Ama şuanlik saldık.
        EventCreateValidator ecv = new EventCreateValidator();              // normalde bu kısımlarında Dependecy Injection ile enjekte edilmesi gerekiyor. Ama şuanlik saldık.

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Event _event)
        {
            var result = ecv.Validate(_event);
            
            if (_event != null && result.IsValid)
            {
                var userEmail = User.FindFirstValue(ClaimTypes.Email);                                           // login yapan user'in emailini aldık
                var user = um.TGetUserByEmail(userEmail);
                _event.UserID = user.UserID;                                                                     // eventi oluştaranın kim oldugunu belirttik.

                em.TInsert(_event);
                _event.EventUrl = em.GenerateRandomUrl() + "?eventid=" + _event.EventID.ToString();
                _event.EventFullUrl = "/EventFinal/Index/" + _event.EventUrl;
                em.TUpdate(_event);

                string jsonString2 = System.Text.Json.JsonSerializer.Serialize(_event);
                TempData["EventData"] = jsonString2;

                HttpContext.Session.SetString("EventData", JsonConvert.SerializeObject(_event));                  // _event'in tüm verilerini EventData isminde bir Key'e atadık. Bu keyde Sessionda tutuluyor.

                return RedirectToAction("Index", "EventFinal", new { id = _event.EventUrl, eventid = _event.EventID } );
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




        //[HttpPost]
        //public IActionResult Index(Event _event)
        //{
        //    //if (ModelState.IsValid) 
        //    if (_event != null)
        //    {
        //        var userEmail = User.FindFirstValue(ClaimTypes.Email);  // login yapan user'in emailini aldık

        //        Context context = new Context();
        //        var user = context.Users.FirstOrDefault(x => x.Email == userEmail);
        //        _event.EventCreatorID = user.UserID;

        //        em.TInsert(_event);
        //        user.EventID = _event.EventID;
        //        context.SaveChanges();

        //        //var currentUsers = context.Users.Include(u => u.Events).Where(u => u.EventID == _event.EventID).ToList();
        //        //var currentEvent = context.Events.Include(x => x.Users).FirstOrDefault(x => x.EventID == _event.EventID);  // LINQ SORGUSU
        //        //var currentEvent = context.Events.Include(e => e.Users).FirstOrDefault(e => e.EventID == _event.EventID);
        //        ////var currentUsers = context.Users.Where(y => y.EventID == _event.EventID).FirstOrDefault();
        //        //if (currentEvent != null)
        //        //{
        //        //    viewModel._Event = currentEvent;
        //        //    viewModel._User = currentEvent.Users;   // viewModel._User null dönüyor !!!!
        //        //    context.SaveChanges();
        //        //}

        //        string jsonString = System.Text.Json.JsonSerializer.Serialize(viewModel);
        //        TempData["ViewModel"] = jsonString;

        //        return RedirectToAction("Index", "EventFinal");
        //    }
        //    else
        //    {
        //        return View();

        //    }
        //}


        //[HttpPost]
        //public IActionResult Index(Event _event)
        //{
        //    //if (ModelState.IsValid) 
        //    if (_event != null)
        //    {
        //        var userEmail = User.FindFirstValue(ClaimTypes.Email);  // login yapan user'in emailini aldık

        //        Context context = new Context();

        //        var user = context.Users.FirstOrDefault(x => x.Email == userEmail);
        //        _event.EventCreatorID = user.UserID;

        //        em.TInsert(_event);
        //        context.SaveChanges();

        //        user.EventID = _event.EventID;   // burası çalışmıyor ??? , saveChanges() ile artık çalışıyor.
        //        context.SaveChanges();
        //        if (user.EventID == _event.EventID)
        //        {
        //            var eventUsers = context.Events.Include(x => x.User).FirstOrDefault(x => x.EventID == user.EventID);  // LINQ SORGUSU

        //            var viewModel = new UserEventViewModel
        //            {
        //                _Event = _event,
        //                _User = eventUsers.User.ToList()
        //            };

        //            ViewBag.viewModel = viewModel;
        //            return RedirectToAction("Index", "EventFinal");
        //        }
        //        else
        //        {
        //            return View();
        //        }
        //    }
        //    else
        //    {
        //        return View();

        //    }
        //}





    }
}
