using RestaurantApp.EntityLayer.Entities;

namespace RestaurantApp.DataAccessLayer.Abstracts
{
    public interface IOrderDal : IGenericDal<Order>
    {
        int TotalOrderCount();
        decimal TodayTotalPrice();
    }
}
