using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestaurantApp.WebUI.Dtos.SocialMediaDtos;


namespace RestaurantApp.WebUI.ViewComponents.UILayoutComponents
{
	public class _UILayoutFooterSocialMediaPartialComponent : ViewComponent
	{
        private readonly IHttpClientFactory _httpClientFactory;
        public _UILayoutFooterSocialMediaPartialComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7113/api/SocialMedias");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultSocialMediaDto>>(jsonData);
            return View(values);
        }
    }
}
