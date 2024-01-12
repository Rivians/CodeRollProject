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
        EventSummaryViewModel _eventSummaryViewModel = new EventSummaryViewModel();
        UserManager um = new UserManager(new EfUserRepository());
        Context context = new Context();

        [HttpGet]
        public IActionResult Index(int eventid)
        {
            //var data = TempData["eventDatas"].ToString();
            //var currentEvent = System.Text.Json.JsonSerializer.Deserialize<Event>(data);
            //ViewBag.Event = currentEvent;

            var currentEvent = context.Events.FirstOrDefault(e => e.EventID == eventid);
            ViewBag.Event = currentEvent;

            var value = context.Events.Include(e => e.Votes).ThenInclude(e => e.VoteOptions).Where(e => e.EventID == eventid).FirstOrDefault();  // henüz denenmedi, ilk önce eventFinal'ı hallet !!

            _eventSummaryViewModel.Votes = value.Votes.ToList();  // henüz denenmedi, ilk önce eventFinal'ı hallet !!
            //_eventSummaryViewModel.Votes = context.Votes.Where(v => v.EventID == currentEvent.EventID).OrderBy(v => v.UserID).ToList();
            //_eventSummaryViewModel.Users = context.EventsUsers.Include(eu => eu.User).Where(eu => eu.EventID == currentEvent.EventID).Select(eu => eu.User).ToList();

            return View(_eventSummaryViewModel);
        }
    }
}
