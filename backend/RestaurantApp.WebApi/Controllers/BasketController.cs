using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantApp.BusinessLayer.Abstracts;
using RestaurantApp.DataAccessLayer.Concretes;
using RestaurantApp.DtoLayer.BasketDto;
using RestaurantApp.WebApi.Models;

namespace RestaurantApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;

        public BasketController(IBasketService basketService)
        {
            this._basketService = basketService;
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var values = _basketService.TGetBasketByMenuTableNumber(id);
            return Ok(values);
        }
        [HttpGet("BasketListWithProductName/{id}")]
        public IActionResult BasketListWithProductName(int id)
        {
            using var context = new SignalRContext();
            var values = context.Baskets
                .Include(x => x.Product)
                .Where(y => y.MenuTableID == id)
                .Select(z => new ResultBasketWithProducts
                {
                    BasketId = z.BasketID,
                    Count = z.Count,
                    MenuTableID = z.MenuTableID,
                    Price = z.Price,
                    ProductID = z.ProductID,
                    ProductName = z.Product.Name,
                    TotalPrice = z.TotalPrice
                }
                ).ToList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateBasket(CreateBasketDto createBasketDto)
        {
            using var context = new SignalRContext();
            _basketService.TAdd(new EntityLayer.Entities.Basket()
            {
                ProductID = createBasketDto.ProductID,
                Count = 1,
                MenuTableID = 1,
                Price = context.Products
                .Where(x => x.Id == createBasketDto.ProductID)
                .Select(y => y.Price).FirstOrDefault(),
                TotalPrice = 0
            });
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBasket(int id)
        {
            var value = _basketService.TGetById(id);
            _basketService.TDelete(value);
            return Ok("Ürün sepetten çıkarıldı.");
        }

    }
}
