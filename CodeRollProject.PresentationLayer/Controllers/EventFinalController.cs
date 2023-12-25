using Microsoft.AspNetCore.Mvc;

namespace CodeRollProject.PresentationLayer.Controllers
{
    public class EventFinalController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
