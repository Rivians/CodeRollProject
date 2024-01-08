using CodeRollProject.BusinessLayer.Concrete;
using CodeRollProject.DataAccessLayer.Concrete;
using CodeRollProject.DataAccessLayer.EntityFramework;
using CodeRollProject.EntityLayer.Concrete;
using CodeRollProject.PresentationLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace CodeRollProject.PresentationLayer.Controllers
{
    [Authorize]
    public class EventFinalController : Controller
    {
        EventManager em = new EventManager(new EfEventRepository());
        UserManager um = new UserManager(new EfUserRepository());
        VoteManager vm = new VoteManager(new EfVoteRepository());
        EventUserManager eum = new EventUserManager(new EfEventUserRepository());
        Context context = new Context();

        [HttpGet]
        public IActionResult Index(string randomUrl,int a) // post olan index action'un parametresinden farklı olsun diye int a ekledik. aslında kullanılmıyor.
        {
            var data = TempData["eventid"].ToString();
            var eventId = System.Text.Json.JsonSerializer.Deserialize<int>(data);

            Event value = context.Events.FirstOrDefault(e => e.EventID == eventId);
            var users = context.EventsUsers.Include(eu => eu.User).Where(eu2 => eu2.EventID == eventId).Select(eu3 => eu3.User);
            ViewBag.Users = users;

            return View(value);
        }

        [HttpPost]
        public IActionResult Index(string selectedOption)
        {
            var userEmail = User.FindFirstValue(ClaimTypes.Email);
            var user = context.Users.FirstOrDefault(u => u.Email == userEmail);

            var data = TempData["eventDatas"].ToString();
            var currentEvent = System.Text.Json.JsonSerializer.Deserialize<Event>(data);

            var Vote = new Vote
            {
                VoteOption = selectedOption,
                UserID = user.UserID,
                EventID = currentEvent.EventID
            };

            var eu = new EventUser();
            eu.EventID = currentEvent.EventID;
            eu.UserID = (int)currentEvent.EventCreatorID;
            context.SaveChanges();

            eum.TInsert(eu);
            vm.TInsert(Vote);
            context.SaveChanges();

            return RedirectToAction("Index", "EventSummary", new { id = currentEvent.EventUrl });
        }
    }
}