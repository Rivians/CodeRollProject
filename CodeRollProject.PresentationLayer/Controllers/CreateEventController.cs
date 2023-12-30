using CodeRollProject.BusinessLayer.Concrete;
using CodeRollProject.DataAccessLayer.Concrete;
using CodeRollProject.DataAccessLayer.EntityFramework;
//using CodeRollProject.DtoLayer.Dtos.CreateEventDto;
using CodeRollProject.EntityLayer.Concrete;
using CodeRollProject.PresentationLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Security.Claims;

namespace CodeRollProject.PresentationLayer.Controllers
{
    public class CreateEventController : Controller
    {
        EventManager em = new EventManager(new EfEventRepository());
        UserEventViewModel viewModel = new UserEventViewModel();

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Event _event)
        {
            //if (ModelState.IsValid) 
            if (_event != null)
            {
                var userEmail = User.FindFirstValue(ClaimTypes.Email);  // login yapan user'in emailini aldık

                Context context = new Context();
                var user = context.Users.FirstOrDefault(x => x.Email == userEmail);
                _event.EventCreatorID = user.UserID;

                em.TInsert(_event);
                context.SaveChanges();

                //user.EventID = _event.EventID;   // burası çalışmıyor ??? , saveChanges() ile artık çalışıyor. BU SATIRA GEREK YOK.
                //context.SaveChanges();

                var currentEvent = context.Events.Include(x => x.Users).FirstOrDefault(x => x.EventID == _event.EventID);  // LINQ SORGUSU
                //var currentUsers = context.Users.Where(y => y.EventID == _event.EventID).FirstOrDefault();
                if (currentEvent != null)
                {
                    viewModel._Event = currentEvent;
                    viewModel._User = currentEvent.Users;
                    //viewModel._User = currentUsers;
                    context.SaveChanges();
                    
                }

                string jsonString = System.Text.Json.JsonSerializer.Serialize(viewModel);
                TempData["ViewModel"] = jsonString;

                return RedirectToAction("Index", "EventFinal");
            }
            else
            {
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
