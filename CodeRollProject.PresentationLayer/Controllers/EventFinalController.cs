using CodeRollProject.BusinessLayer.Concrete;
using CodeRollProject.DataAccessLayer.Concrete;
using CodeRollProject.DataAccessLayer.EntityFramework;
using CodeRollProject.EntityLayer.Concrete;
using CodeRollProject.PresentationLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodeRollProject.PresentationLayer.Controllers
{
    public class EventFinalController : Controller
    {
        EventManager em = new EventManager(new EfEventRepository());
        UserManager um = new UserManager(new EfUserRepository());
        Context c = new Context();

        [HttpGet]
        public IActionResult Index(int eventID)
        {
            var eventValues = em.TGetByID(eventID);
            //var eventUsers = c.Users.Where()

            return View(eventValues);
        }

    }
}
