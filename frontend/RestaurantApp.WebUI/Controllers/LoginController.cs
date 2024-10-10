﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RestaurantApp.EntityLayer.Entities;
using RestaurantApp.WebUI.Dtos.IdentityDtos;

namespace RestaurantApp.WebUI.Controllers
{
	public class LoginController : Controller
	{
		private readonly SignInManager<AppUser> _signInManager;

		public LoginController(SignInManager<AppUser> signInManager)
		{
			_signInManager = signInManager;
		}
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public async  Task<IActionResult> Index(LoginDto loginDto)
		{
			var result  = await _signInManager
				.PasswordSignInAsync(loginDto.Username, loginDto.Password, false, false);
			if (result.Succeeded)
			{
				return Redirect("/Home/Index");
			}
			return View();
		}
	}
}
