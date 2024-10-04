using RestaurantApp.DataAccessLayer.Abstracts;
using RestaurantApp.DataAccessLayer.Concretes;
using RestaurantApp.DataAccessLayer.Repositories;
using RestaurantApp.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.DataAccessLayer.EntityFramework
{
    public class EfOrderDal : GenericRepository<Order>, IOrderDal
    {
        public EfOrderDal(SignalRContext context) : base(context)
        {
        }

        public int TotalOrderCount()
        {
            var context = new SignalRContext();
            return context.Orders.Count();
        }
        public decimal TodayTotalPrice()
        {
            using var context = new SignalRContext();

            DateTime NowDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            return context.Orders.Where(x => x.Date == NowDate && x.Description == "Hesap Kapatıldı").Sum(x => x.TotalPrice);
        }
    }
}
