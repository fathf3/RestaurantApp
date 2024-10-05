using Microsoft.AspNetCore.Mvc;

namespace RestaurantApp.WebUI.ViewComponents.UILayoutComponents
{
    public class _UILayoutHeaderPartialComponent : ViewComponent
    {
        public IViewComponentResult Invoke() { return View(); }
    }
}
