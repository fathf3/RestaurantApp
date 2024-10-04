using RestaurantApp.EntityLayer.Entities;

namespace RestaurantApp.DataAccessLayer.Abstracts
{
    public interface ICategoryDal : IGenericDal<Category>
    {
        public int GetCategoryCount();
        public int ActiveCategoryCount();
        public int PassiveCategoryCount();
    }
}
