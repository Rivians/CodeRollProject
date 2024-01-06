using CodeRollProject.DataAccessLayer.Concrete;
using CodeRollProject.EntityLayer.Concrete;
using CodeRollProject.PresentationLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodeRollProject.PresentationLayer.Controllers
{
    public class EventSummaryController : Controller
    {
        EventSummaryViewModel _eventSummaryViewModel = new EventSummaryViewModel();
        Context context = new Context();

        public IActionResult Index()
        {
            var data = TempData["eventDatas"].ToString();
            var currentEvent = System.Text.Json.JsonSerializer.Deserialize<Event>(data);
            ViewBag.Event = currentEvent;

            //_eventSummaryViewModel.Votes = context.Users.Include(x => x.Votes).Select(x => x.Votes).FirstOrDefault();
            //_eventSummaryViewModel.Votes = context.EventsUsers.Include(eu => eu.User).ThenInclude(eu => eu.Votes).Where(eu => eu.EventID == currentEvent.EventID).SelectMany(eu => eu.User.Votes).ToList();
            //_eventSummaryViewModel.Votes = context.Votes.Include(v => v.User).Where(v => v.EventID == currentEvent.EventID).ToList();  // ????????????
            _eventSummaryViewModel.Votes = context.Votes.Where(v => v.EventID == currentEvent.EventID).OrderBy(v => v.UserID).ToList();

            _eventSummaryViewModel.Users = context.EventsUsers.Include(eu => eu.User).Where(eu => eu.EventID == currentEvent.EventID).Select(eu => eu.User).ToList();
            //_eventSummaryViewModel.Votes = context.Users.Include(u => u.Votes).Where()

            return View(_eventSummaryViewModel);
        }
    }
}
