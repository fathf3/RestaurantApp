﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestaurantApp.WebUI.Dtos.BasketDtos;
using RestaurantApp.WebUI.Dtos.ProductDtos;
using System.Text;

namespace RestaurantApp.WebUI.Controllers
{
    [AllowAnonymous]
    public class MenuController : Controller
    {

        private readonly IHttpClientFactory _httpClientFactory;
        public MenuController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index()
        {
            //ViewBag.v = id; // Burada MenuTableId değerini ayarlıyoruz
                            // TempData["x"] = id; // Eğer bunu kullanıyorsanız

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7113/api/Products/");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
            return View(values);
        }
        [HttpPost]
        public async Task<IActionResult> AddBasket(int id)
        {
            CreateBasketDto createBasketDto = new CreateBasketDto();
            createBasketDto.ProductId = id;
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createBasketDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7113/api/Basket", stringContent);
            if (response.IsSuccessStatusCode)
            {
                return Redirect("/Menu/Index");
            }
            return Json(createBasketDto);
        }
    }
}
