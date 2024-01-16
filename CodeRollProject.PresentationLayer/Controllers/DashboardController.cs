using CodeRollProject.BusinessLayer.Abstract;
using CodeRollProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Security.Claims;

namespace CodeRollProject.PresentationLayer.Controllers
{
	[Authorize]
	public class DashboardController : Controller
	{
		private readonly IEventService em;
		private readonly IUserService um;
        public DashboardController(IEventService eventManager, IUserService userManager)
        {
            em = eventManager;
			um = userManager;
        }

        public IActionResult Index()
		{
			var email = User.FindFirstValue(ClaimTypes.Email);
			var user = um.TGetUserByEmail(email);

			var last5event = em.TGetLast5EventByUserId(user.UserID);
			return View(last5event);
		}

		public IActionResult DeleteEvent(int id)
        {
			Event eventt = em.TGetEventById(id);
			em.TDelete(eventt);
			return RedirectToAction("Index");
		}
	}
}
