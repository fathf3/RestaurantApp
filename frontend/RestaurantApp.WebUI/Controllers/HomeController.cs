﻿using Microsoft.AspNetCore.Mvc;
using RestaurantApp.WebUI.Models;
using System.Diagnostics;

namespace RestaurantApp.WebUI.Controllers
{
    public class HomeController : Controller
    {
        

        public IActionResult Index()
        {
            return View();
        }

        
    }
}
