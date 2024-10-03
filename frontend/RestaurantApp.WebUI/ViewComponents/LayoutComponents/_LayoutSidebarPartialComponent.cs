using Microsoft.AspNetCore.Mvc;

namespace RestaurantApp.WebUI.ViewComponents.LayoutComponents
{
	public class _LayoutSidebarPartialComponent : ViewComponent
	{
		public IViewComponentResult Invoke() {  return View(); }
	}
}
