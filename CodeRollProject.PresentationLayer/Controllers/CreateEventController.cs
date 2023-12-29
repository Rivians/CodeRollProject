using CodeRollProject.BusinessLayer.Concrete;
using CodeRollProject.DataAccessLayer.Concrete;
using CodeRollProject.DataAccessLayer.EntityFramework;
//using CodeRollProject.DtoLayer.Dtos.CreateEventDto;
using CodeRollProject.EntityLayer.Concrete;
using CodeRollProject.PresentationLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace CodeRollProject.PresentationLayer.Controllers
{
    public class CreateEventController : Controller
    {
        EventManager em = new EventManager(new EfEventRepository());

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
                var userEmail = User.FindFirstValue(ClaimTypes.Email);

                Context context = new Context();

                var user = context.Users.FirstOrDefault(x => x.Email == userEmail);
                _event.EventCreatorID = user.UserID;
                
                em.TInsert(_event);
                context.SaveChanges();

                user.EventID = _event.EventID;   // burası çalışmıyor ???
                context.SaveChanges();
                if(user.EventID == _event.EventID)
                {
                    var eventUsers = context.Events.Include(x => x.User).FirstOrDefault(x => x.EventID == user.EventID);  // LINQ SORGUSU

                    //var viewModel = new UserEventViewModel
                    //{                                                 ŞİMDİ BURASI KALDI, YAPMAMIZ GEREKEN VİEWMODEL İLE FİNAL PAGEDE 2 ENTITY KULLANMAK !!
                    //    _Event = _event,
                    //    _User = eventUsers.User.ToList(),
                    //};

                    return RedirectToAction("Index", "EventFinal", _event);
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return View();

            }
        }

        //[HttpPost]
        //public IActionResult Index(Event _event)
        //{
        //    if(ModelState.IsValid)
        //    {
        //        em.TInsert(_event);
        //        return RedirectToAction("Index", "EventFinal", _event);
        //    }
        //    else
        //    {
        //        return View();

        //    }
        //}



    }
}
