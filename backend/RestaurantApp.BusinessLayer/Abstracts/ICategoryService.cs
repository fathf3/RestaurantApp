using RestaurantApp.EntityLayer.Entities;

namespace RestaurantApp.BusinessLayer.Abstracts
{
    public interface ICategoryService : IGenericService<Category>
    {
         int TGetCategoryCount();
         int TActiveCategoryCount();
         int TPassiveCategoryCount();
    }
    
}
