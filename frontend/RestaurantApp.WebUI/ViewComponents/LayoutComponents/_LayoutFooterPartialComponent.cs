using Microsoft.AspNetCore.Mvc;

namespace RestaurantApp.WebUI.ViewComponents.LayoutComponents
{
	public class _LayoutFooterPartialComponent : ViewComponent
	{
		public IViewComponentResult Invoke() {  return View(); }
	}
}
