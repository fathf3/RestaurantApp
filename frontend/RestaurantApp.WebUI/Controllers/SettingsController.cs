﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RestaurantApp.EntityLayer.Entities;
using RestaurantApp.WebUI.Dtos.IdentityDtos;

namespace RestaurantApp.WebUI.Controllers
{
    public class SettingsController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public SettingsController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var value =  await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditDto userEditDto = new UserEditDto();
            userEditDto.Name = value.Name;
            userEditDto.Surname = value.Surname;
            userEditDto.UserName = value.UserName;
            userEditDto.Mail = value.Email;
            
            return View(userEditDto);
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserEditDto userEditDto)
        {
            if(userEditDto.Password == userEditDto.ConfirmPassword)
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                user.Name = userEditDto.Name;
                user.Surname = userEditDto.Surname;
                user.UserName = userEditDto.UserName;
                user.Email = userEditDto.Mail;
                user.PasswordHash = _userManager
                    .PasswordHasher
                    .HashPassword(user, userEditDto.Password);
                var result = await _userManager.UpdateAsync(user);
                return Redirect("/Home/Index");
            }
            return View();

        }
    }
}
