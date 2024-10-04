using RestaurantApp.EntityLayer.Entities;

namespace RestaurantApp.DataAccessLayer.Abstracts
{
    public interface IProductDal : IGenericDal<Product>
    {
        public List<Product> GetProductsWithCategory();
        public int GetProductCount();
        public int ProductCountByCategoryNameHamburger();

    }
}
