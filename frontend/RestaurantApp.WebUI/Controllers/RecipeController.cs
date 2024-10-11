using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestaurantApp.WebUI.Dtos.ReceipeDtos;

namespace RestaurantApp.WebUI.Controllers
{
    public class RecipeController : Controller
    {
        public async Task<IActionResult> Index()
        {

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://tasty.p.rapidapi.com/recipes/list?from=0&size=40&tags=under_30_minutes"),
                Headers =
    {
        { "x-rapidapi-key", "a2c2e36cccmshf525ca733a1354cp1a4bdajsn5d634bcb1845" },
        { "x-rapidapi-host", "tasty.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();

                //var values = JsonConvert.DeserializeObject<List<ResultReceipeDto>>(body);
                //return View(values);

                var root = JsonConvert.DeserializeObject<RootTastyApi>(body);
                var values = root.Results;
                return View(values.ToList());

            }
            
        }
    }
}
