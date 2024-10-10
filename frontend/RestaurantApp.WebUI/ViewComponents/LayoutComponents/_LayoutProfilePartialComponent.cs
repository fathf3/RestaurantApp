using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RestaurantApp.EntityLayer.Entities;
using RestaurantApp.WebUI.Dtos.IdentityDtos;

namespace RestaurantApp.WebUI.ViewComponents.LayoutComponents
{
    public class _LayoutProfilePartialComponent : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

        public _LayoutProfilePartialComponent(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var value = await _userManager.FindByNameAsync(User.Identity.Name);
            ResultUserDto resultUserDto = new ResultUserDto();
            resultUserDto.Name = value.Name;
            resultUserDto.Mail = value.Email;
            resultUserDto.Surname = value.Surname;
            return View(resultUserDto);
        }
    }
}
