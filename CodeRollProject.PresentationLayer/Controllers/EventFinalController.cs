using CodeRollProject.BusinessLayer.Concrete;
using CodeRollProject.DataAccessLayer.Concrete;
using CodeRollProject.DataAccessLayer.EntityFramework;
using CodeRollProject.EntityLayer.Concrete;
using CodeRollProject.PresentationLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodeRollProject.PresentationLayer.Controllers
{
    public class EventFinalController : Controller
    {
        EventManager em = new EventManager(new EfEventRepository());
        UserManager um = new UserManager(new EfUserRepository());
        EventUserManager eum = new EventUserManager(new EfEventUserRepository());
        Context context = new Context();

        [HttpGet]
        public IActionResult Index()
        {
            var data = TempData["eventid"].ToString();
            var eventId = System.Text.Json.JsonSerializer.Deserialize<int>(data);

            Event value = context.Events.FirstOrDefault(e => e.EventID == eventId);
            var users = context.EventsUsers.Include(eu => eu.User).Where(eu2 => eu2.EventID == eventId).Select(eu3 => eu3.User);
            ViewBag.Users = users;

            return View(value);
        }
    }
}
