using CodeRollProject.BusinessLayer.Concrete;
using CodeRollProject.DataAccessLayer.EntityFramework;
//using CodeRollProject.DtoLayer.Dtos.CreateEventDto;
using CodeRollProject.EntityLayer.Concrete;
using CodeRollProject.PresentationLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CodeRollProject.PresentationLayer.Controllers
{
    public class CreateEventController : Controller
    {
        EventManager em = new EventManager(new EfEventRepository());

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Event _event)
        {
            if(ModelState.IsValid)
            {
                em.TInsert(_event);
                //UserEventVoteViewModel uev = new UserEventVoteViewModel();
                //uev._event = _event;
                return RedirectToAction("Index","EventFinal",_event);
            }
            else
            {
                return View();
            }          
        }
    }
}
