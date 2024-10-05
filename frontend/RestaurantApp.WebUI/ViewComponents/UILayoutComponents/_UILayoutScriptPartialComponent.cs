using Microsoft.AspNetCore.Mvc;

namespace RestaurantApp.WebUI.ViewComponents.UILayoutComponents
{
    public class _UILayoutScriptPartialComponent : ViewComponent
    {
        public IViewComponentResult Invoke() { return View(); }
    }
}
