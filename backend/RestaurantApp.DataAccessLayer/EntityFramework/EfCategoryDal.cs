using RestaurantApp.DataAccessLayer.Abstracts;
using RestaurantApp.DataAccessLayer.Concretes;
using RestaurantApp.DataAccessLayer.Repositories;
using RestaurantApp.EntityLayer.Entities;

namespace RestaurantApp.DataAccessLayer.EntityFramework
{
    public class EfCategoryDal : GenericRepository<Category>, ICategoryDal
    {
        public EfCategoryDal(SignalRContext context) : base(context)
        {
        }

        public int ActiveCategoryCount()
        {
            var context = new SignalRContext();
            return context.Categories.Where(x => x.Status == true).Count();
        }

        public int GetCategoryCount()
        {
            var context = new SignalRContext();
            return context.Categories.Count();
        }

        public int PassiveCategoryCount()
        {
            var context = new SignalRContext();
            return context.Categories.Where(x => x.Status != true).Count();
        }
    }
}
