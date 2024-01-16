using CodeRollProject.BusinessLayer.Abstract;
using CodeRollProject.BusinessLayer.Concrete;
using CodeRollProject.DataAccessLayer.Concrete;
using CodeRollProject.DataAccessLayer.EntityFramework;
using CodeRollProject.EntityLayer.Concrete;
using CodeRollProject.PresentationLayer.Models;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MimeKit;
using Newtonsoft.Json;
using System.Security.Claims;

namespace CodeRollProject.PresentationLayer.Controllers
{
    [AllowAnonymous]
    [Authorize]
    public class EventSummaryController : Controller
    {
        private readonly IUserService um;
        private readonly IEventService em;
        private readonly IVoteService vm;
        Context c = new Context();
        public EventSummaryController(IUserService userManager, IEventService eventManager, IVoteService voteManager)
        {
            um = userManager;
            em = eventManager;
            vm = voteManager;
        }

        EventSummaryViewModel _eventSummaryViewModel = new EventSummaryViewModel();
        Context context = new Context();


        [HttpGet]
        public IActionResult Index(int eventid)
        {
            var currentEvent = em.TGetEventById(eventid);
            ViewBag.Event = currentEvent;
            ViewBag.EventFullUrl = currentEvent.EventFullUrl;

            _eventSummaryViewModel.eventt = currentEvent;
            _eventSummaryViewModel.votess = currentEvent.Votes.ToList();

            _eventSummaryViewModel.vote1Count = c.VoteOptions.Count(vo => vo.VoteValue == currentEvent.EventTime1.ToString());
            _eventSummaryViewModel.vote2Count = c.VoteOptions.Count(vo => vo.VoteValue == currentEvent.EventTime2.ToString());
            _eventSummaryViewModel.vote3Count = c.VoteOptions.Count(vo => vo.VoteValue == currentEvent.EventTime3.ToString());

            return View(_eventSummaryViewModel);
        }
    }
}
