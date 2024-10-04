using Microsoft.AspNetCore.Mvc;

namespace RestaurantApp.WebUI.Controllers
{
    public class SignalRDefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
