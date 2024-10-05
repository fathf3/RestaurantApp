using RestaurantApp.EntityLayer.Entities;

namespace RestaurantApp.BusinessLayer.Abstracts
{
    public interface IDiscountService : IGenericService<Discount>
    {
        void TChangeStatusToTrue(int id);
        void TChangeStatusToFalse(int id);
        List<Discount> TGetListByStatusTrue();
    }
    
}
