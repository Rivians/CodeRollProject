using CodeRollProject.BusinessLayer.Concrete;
using CodeRollProject.DataAccessLayer.EntityFramework;
using CodeRollProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CodeRollProject.PresentationLayer.Controllers
{
    public class EventFinalController : Controller
    {
        EventManager em = new EventManager(new EfEventRepository());

        [HttpGet]
        public IActionResult Index(int eventID)
        {
            var eventValues = em.TGetByID(eventID);
            return View(eventValues);
        }
    }
}
