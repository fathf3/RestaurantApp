using RestaurantApp.EntityLayer.Entities;

namespace RestaurantApp.BusinessLayer.Abstracts
{
    public interface IOrderService : IGenericService<Order>
    {
        int TTotalOrderCount();
        decimal TTodayTotalPrice();
    }

}
