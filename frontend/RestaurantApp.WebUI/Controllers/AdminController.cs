using Microsoft.AspNetCore.Mvc;

namespace RestaurantApp.WebUI.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
