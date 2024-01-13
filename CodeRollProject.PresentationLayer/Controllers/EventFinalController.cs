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
        //EventManager em = new EventManager(new EfEventRepository());
        //UserManager um = new UserManager(new EfUserRepository());
        //VoteManager vm = new VoteManager(new EfVoteRepository());
        //VoteOptionManager vom = new VoteOptionManager(new EfVoteOptionRepository());

        private readonly EventManager em;
        private readonly UserManager um;
        private readonly VoteManager vm;
        private readonly VoteOptionManager vom;

        EventVoteViewModel evwm = new EventVoteViewModel();
        Context context = new Context();

        public EventFinalController(EventManager eventManager, UserManager userManager, VoteManager voteManager, VoteOptionManager voteOptionManager)
        {
            em = eventManager;
            um = userManager;
            vm = voteManager;
            vom = voteOptionManager;
        }

        [HttpGet] 
        public IActionResult Index(int eventid) 
        {
            //var data = TempData["eventid"].ToString();
            //var eventId = System.Text.Json.JsonSerializer.Deserialize<int>(data);

            //Event value = context.Events.FirstOrDefault(e => e.EventID == eventid);
            //var users = context.EventsUsers.Include(eu => eu.User).Where(eu2 => eu2.EventID == eventid).Select(eu3 => eu3.User);
            //ViewBag.Users = users;

            var eventValue = context.Events.Include(e => e.Votes).ThenInclude(e => e.VoteOptions).FirstOrDefault(e => e.EventID == eventid);        
            var eventParticipants = eventValue.Votes.ToList();
            ViewBag.eventParticipants = eventParticipants;

            evwm = new EventVoteViewModel()
            {
                eventt = eventValue        
            };

            //var eventDataWithVotes = context.Events.Where(e => e.EventID != eventid).Select(e => new { Event = e, Vote = e.Votes });
            //return View(value);
            return View(evwm);
        }

        [HttpPost]
        public IActionResult Index(EventVoteViewModel _eventVoteViewModel) // ŞUAN Kİ VERSİYONDA _vote null dönüyor. 
        {
            var userEmail = User.FindFirstValue(ClaimTypes.Email);
            var user = context.Users.FirstOrDefault(u => u.Email == userEmail);

            var data = TempData["EventData"].ToString();
            var currentEvent = System.Text.Json.JsonSerializer.Deserialize<Event>(data);
         
            var vote = new Vote
            {
                EventID = currentEvent.EventID,
                ParticipantName = _eventVoteViewModel.participantName
            };

            if (vote != null)
            {
                vm.TInsert(vote);
                context.SaveChanges();
            }

            var voteS = context.Votes.Include(v => v.VoteOptions).FirstOrDefault(v => v.ParticipantName == _eventVoteViewModel.participantName);

            for (int i = 0; i < _eventVoteViewModel.SelectedOption.Count; i++)
            {
                var voteOptionValue = _eventVoteViewModel.SelectedOption[i];

                if(i < voteS.VoteOptions.Count)
                {
                    voteS.VoteOptions[i].VoteValue = voteOptionValue;
                    context.SaveChanges();
                }
                else
                {
                    var newVoteOption = new VoteOption
                    {
                        VoteID = voteS.VoteID,
                        VoteValue = voteOptionValue
                    };
                    vom.TInsert(newVoteOption);
                    context.SaveChanges();
                }
            }

            return RedirectToAction("Index", "EventSummary", new { id = currentEvent.EventUrl, eventid = currentEvent.EventID });
            //return View();
        }
    }
}