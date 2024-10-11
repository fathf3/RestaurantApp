using RestaurantApp.EntityLayer.Entities;

namespace RestaurantApp.BusinessLayer.Abstracts
{
    public interface IProductService : IGenericService<Product>
    {
        List<Product> TGetProductsWithCategory();
        int TGetProductCount();

        int TProductCountByCategoryNameHamburger();
        List<Product> GetLast9Product();
    }
    
}
