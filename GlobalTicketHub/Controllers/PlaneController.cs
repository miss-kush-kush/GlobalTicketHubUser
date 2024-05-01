using Microsoft.AspNetCore.Mvc;

namespace GlobalTicketHub.Controllers
{
    public class PlaneController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
