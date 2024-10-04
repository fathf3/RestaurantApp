using RestaurantApp.DataAccessLayer.Abstracts;
using RestaurantApp.DataAccessLayer.Concretes;
using RestaurantApp.DataAccessLayer.Repositories;
using RestaurantApp.EntityLayer.Entities;

namespace RestaurantApp.DataAccessLayer.EntityFramework
{
    public class EfOrderDetailDal : GenericRepository<OrderDetail>, IOrderDetailDal
    {
        public EfOrderDetailDal(SignalRContext context) : base(context)
        {
        }
    }
}
