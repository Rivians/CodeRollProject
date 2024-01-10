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
        EventVoteViewModel evwm = new EventVoteViewModel();
        Context context = new Context();

        [HttpGet]
        public IActionResult Index(int eventid) 
        {
            //var data = TempData["eventid"].ToString();
            //var eventId = System.Text.Json.JsonSerializer.Deserialize<int>(data);

            //Event value = context.Events.FirstOrDefault(e => e.EventID == eventid);
            //var users = context.EventsUsers.Include(eu => eu.User).Where(eu2 => eu2.EventID == eventid).Select(eu3 => eu3.User);
            //ViewBag.Users = users;

            var eventValue = context.Events.Include(e => e.Votes).FirstOrDefault(e => e.EventID == eventid);

            evwm = new EventVoteViewModel()
            {
                eventt = eventValue,
                votee = eventValue.Votes.ToList(),
                
            };

            //var eventDataWithVotes = context.Events.Where(e => e.EventID != eventid).Select(e => new { Event = e, Vote = e.Votes });
            //return View(value);
            return View(evwm);
        }

        [HttpPost]
        public IActionResult Index(Vote _vote) // ŞUAN Kİ VERSİYONDA _vote null dönüyor. 
        {
            var userEmail = User.FindFirstValue(ClaimTypes.Email);
            var user = context.Users.FirstOrDefault(u => u.Email == userEmail);

            var data = TempData["EventData"].ToString();
            var currentEvent = System.Text.Json.JsonSerializer.Deserialize<Event>(data);

            var vote = new Vote
            {
                VoteOption = _vote.VoteOption,
                ParticipantName = _vote.ParticipantName,                
                EventID = currentEvent.EventID
            };

            if(vote == null)
            {
                vm.TInsert(vote);
            }
                       
            context.SaveChanges();

            //return RedirectToAction("Index", "EventSummary", new { id = currentEvent.EventUrl, eventid = currentEvent.EventID });
            return View(); // geçici
        }
    }
}