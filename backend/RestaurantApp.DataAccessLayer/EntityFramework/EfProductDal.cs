using Microsoft.EntityFrameworkCore;
using RestaurantApp.DataAccessLayer.Abstracts;
using RestaurantApp.DataAccessLayer.Concretes;
using RestaurantApp.DataAccessLayer.Repositories;
using RestaurantApp.EntityLayer.Entities;

namespace RestaurantApp.DataAccessLayer.EntityFramework
{
    public class EfProductDal : GenericRepository<Product>, IProductDal
    {
        public EfProductDal(SignalRContext context) : base(context)
        {
        }

        public List<Product> GetLast9Product()
        {
            var context = new SignalRContext();
            var values = context.Products.Take(9).ToList();
            return values;
        }

        public int GetProductCount()
        {
            var context = new SignalRContext();
            return context.Products.Count();
        }

        public List<Product> GetProductsWithCategory()
        {
            var context = new SignalRContext();
            var values = context.Products.Include(p => p.Category).ToList();
            return values;
        }

        public int ProductCountByCategoryNameHamburger()
        {
            var context = new SignalRContext();
            var value = context.
                Products.Where(x => x.CategoryId == (context.Categories.Where(y => y.Name == "Hamburger")
                .Select(z => z.Id)
                .FirstOrDefault()))
                .Count();
            return value;
        }
    }
}
