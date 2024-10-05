using RestaurantApp.EntityLayer.Entities;

namespace RestaurantApp.DataAccessLayer.Abstracts
{
    public interface IDiscountDal : IGenericDal<Discount>
    {
        void ChangeStatusToTrue(int id);
        void ChangeStatusToFalse(int id);
        List<Discount> GetListByStatusTrue();
    }
}
