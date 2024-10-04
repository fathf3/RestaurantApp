using Microsoft.AspNetCore.SignalR;
using RestaurantApp.BusinessLayer.Abstracts;

namespace RestaurantApp.WebApi.Hubs
{
    public class SignalRHub : Hub
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;
        private readonly IMenuTableService _menuTableService;

        public SignalRHub(IProductService productService, IOrderService orderService, ICategoryService categoryService, IMenuTableService menuTableService)
        {
            _productService = productService;
            _orderService = orderService;
            _categoryService = categoryService;
            _menuTableService = menuTableService;
        }
        public async Task SendStatistic()
        {
            var value = _categoryService.TGetCategoryCount();
            await Clients.All.SendAsync("ReceiveCategoryCount", value);

            var value2 = _productService.TGetProductCount();
            await Clients.All.SendAsync("ReceiveProductCount", value2);

            var value3 = _categoryService.TActiveCategoryCount();
            await Clients.All.SendAsync("ReceiveActiveCategoryCount", value3);

            var value4 = _categoryService.TPassiveCategoryCount();
            await Clients.All.SendAsync("ReceivePassiveCategoryCount", value4);

            var value5 = _productService.TProductCountByCategoryNameHamburger();
            await Clients.All.SendAsync("ReceiveProductCountByCategoryNameHamburger", value5);

            var value6 = _orderService.TTotalOrderCount();
            await Clients.All.SendAsync("ReceiveTotalOrderCount", value6);
            
            var value7 = _menuTableService.TMenuTableCount();
            await Clients.All.SendAsync("ReceiveMenuTableCount", value7);


        }
    }
}
