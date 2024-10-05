using Microsoft.AspNetCore.Mvc;

namespace RestaurantApp.WebUI.Controllers
{
    public class UILayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
