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
    [Authorize]
    public class EventSummaryController : Controller
    {
        private readonly IUserService um;
        private readonly IEventService em;
        public EventSummaryController(IUserService userManager, IEventService eventManager)
        {
            um = userManager;
            em = eventManager;
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

            return View(_eventSummaryViewModel);
        }
    }
}
