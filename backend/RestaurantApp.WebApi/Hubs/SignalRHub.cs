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
        private readonly IBookingService _bookingService;
        private readonly INotificationService _notificationService;

		public SignalRHub(IProductService productService, IOrderService orderService, ICategoryService categoryService, IMenuTableService menuTableService, IBookingService bookingService, INotificationService notificationService)
		{
			_productService = productService;
			_orderService = orderService;
			_categoryService = categoryService;
			_menuTableService = menuTableService;
			_bookingService = bookingService;
			_notificationService = notificationService;
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


        public async Task GetBookingList()
        {
            var values = _bookingService.TGetListAll();
            await Clients.All.SendAsync("ReceiveBookingList", values);
        }

        public async Task SendNotification()
        {
            var value = _notificationService.NotificationCountByStatusFalse();
            await Clients.All.SendAsync("ReceiveNotificationCountByFalse", value);

            var values = _notificationService.GetAllNotificationsByFalse();
            await Clients.All.SendAsync("ReceiveGetAllNotificationsByFalse", values);
        }
        public async Task GetMenuTableStatus()
        {
            var values = _menuTableService.TGetListAll();
            await Clients.All.SendAsync("ReceiveMenuTableStatus", values);
        }
    }
}
