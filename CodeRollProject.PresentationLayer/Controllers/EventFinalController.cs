using CodeRollProject.BusinessLayer.Abstract;
using CodeRollProject.BusinessLayer.Concrete;
using CodeRollProject.BusinessLayer.ValidationRules;
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
    [AllowAnonymous]
    [Authorize]
    public class EventFinalController : Controller
    {
        private readonly IEventService em;
        private readonly IUserService um;
        private readonly IVoteService vm;
        private readonly IVoteOptionService vom;
        public EventFinalController(IEventService eventManager, IUserService userManager, IVoteService voteManager, IVoteOptionService voteOptionManager)
        {
            em = eventManager;
            um = userManager;
            vm = voteManager;
            vom = voteOptionManager;
        }

        EventVoteViewModel evwm = new EventVoteViewModel();
        ChooseAvailabilityValidator cav = new ChooseAvailabilityValidator();

        [HttpGet] 
        public IActionResult Index(int eventid) 
        {
            var eventValue = em.TGetEventById(eventid);
            var eventParticipants = eventValue.Votes.ToList();
            ViewBag.eventParticipants = eventParticipants;

            evwm = new EventVoteViewModel()
            {
                eventt = eventValue        
            };

            return View(evwm);
        }

        [HttpPost]
        public IActionResult Index(EventVoteViewModel _eventVoteViewModel)  
        {
            var currentEvent = em.TGetEventById(_eventVoteViewModel.postedEventId);

            if(_eventVoteViewModel.participantName != null && _eventVoteViewModel.SelectedOption != null)
            {
                var vote = new Vote
                {
                    EventID = currentEvent.EventID,
                    ParticipantName = _eventVoteViewModel.participantName
                };

                if (vote != null)
                {
                    vm.TInsert(vote);
                }

                var voteS = vm.TGetVoteByParticipantAndEventID(_eventVoteViewModel.participantName, currentEvent.EventID);

                for (int i = 0; i < _eventVoteViewModel.SelectedOption.Count; i++)
                {
                    var voteOptionValue = _eventVoteViewModel.SelectedOption[i];

                    if (i < voteS.VoteOptions.Count)
                    {
                        voteS.VoteOptions[i].VoteValue = voteOptionValue;
                    }
                    else
                    {
                        var newVoteOption = new VoteOption
                        {
                            VoteID = voteS.VoteID,
                            VoteValue = voteOptionValue
                        };
                        vom.TInsert(newVoteOption);
                    }
                }
                return RedirectToAction("Index", "EventSummary", new { id = currentEvent.EventUrl, eventid = currentEvent.EventID });
            }
            else
            {
                return View();
            }
        }
    }
}
