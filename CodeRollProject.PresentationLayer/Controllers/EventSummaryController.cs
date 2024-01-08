﻿using CodeRollProject.DataAccessLayer.Concrete;
using CodeRollProject.EntityLayer.Concrete;
using CodeRollProject.PresentationLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodeRollProject.PresentationLayer.Controllers
{
    [Authorize]
    public class EventSummaryController : Controller
    {
        EventSummaryViewModel _eventSummaryViewModel = new EventSummaryViewModel();
        Context context = new Context();

        public IActionResult Index(string randomUrl)
        {
            var data = TempData["eventDatas"].ToString();
            var currentEvent = System.Text.Json.JsonSerializer.Deserialize<Event>(data);
            ViewBag.Event = currentEvent;

            _eventSummaryViewModel.Votes = context.Votes.Where(v => v.EventID == currentEvent.EventID).OrderBy(v => v.UserID).ToList();
            _eventSummaryViewModel.Users = context.EventsUsers.Include(eu => eu.User).Where(eu => eu.EventID == currentEvent.EventID).Select(eu => eu.User).ToList();

            return View(_eventSummaryViewModel);
        }
    }
}
