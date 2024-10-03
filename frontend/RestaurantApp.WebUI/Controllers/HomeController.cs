using Microsoft.AspNetCore.Mvc;
using RestaurantApp.WebUI.Models;
using System.Diagnostics;

namespace RestaurantApp.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        
    }
}
