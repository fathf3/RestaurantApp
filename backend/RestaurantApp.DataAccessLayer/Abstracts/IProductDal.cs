using RestaurantApp.EntityLayer.Entities;

namespace RestaurantApp.DataAccessLayer.Abstracts
{
    public interface IProductDal : IGenericDal<Product>
    {
        List<Product> GetProductsWithCategory();
    }
}
