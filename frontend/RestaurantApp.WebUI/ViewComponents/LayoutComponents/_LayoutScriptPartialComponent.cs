using Microsoft.AspNetCore.Mvc;

namespace RestaurantApp.WebUI.ViewComponents.LayoutComponents
{
	public class _LayoutScriptPartialComponent : ViewComponent
	{
		public IViewComponentResult Invoke() {  return View(); }
	}
}
