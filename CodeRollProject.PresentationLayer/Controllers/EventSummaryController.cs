using Microsoft.AspNetCore.Mvc;

namespace CodeRollProject.PresentationLayer.Controllers
{
    public class EventSummaryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
