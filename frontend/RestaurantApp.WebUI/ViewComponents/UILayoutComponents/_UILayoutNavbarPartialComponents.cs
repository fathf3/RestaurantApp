using Microsoft.AspNetCore.Mvc;

namespace RestaurantApp.WebUI.ViewComponents.UILayoutComponents
{
    public class _UILayoutNavbarPartialComponents : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
