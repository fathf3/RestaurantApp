using Microsoft.AspNetCore.Mvc;

namespace RestaurantApp.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
