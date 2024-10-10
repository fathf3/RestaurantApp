using RestaurantApp.DataAccessLayer.Abstracts;
using RestaurantApp.DataAccessLayer.Concretes;
using RestaurantApp.DataAccessLayer.Repositories;
using RestaurantApp.EntityLayer.Entities;

namespace RestaurantApp.DataAccessLayer.EntityFramework
{
	public class EfBookingDal : GenericRepository<Booking>, IBookingDal
    {
        public EfBookingDal(SignalRContext context) : base(context)
        {
        }

		public void BookingStatusApproved(int id)
		{
			using var context = new SignalRContext();
			var value = context.Bookings.Find(id);
			value.Description = "Rezervasyon Onaylandı";
			context.SaveChanges();
		}

		public void BookingStatusCancelled(int id)
		{
			using var context = new SignalRContext();
			var value = context.Bookings.Find(id);
			value.Description = "Rezervasyon İptal Edildi";
			context.SaveChanges();
		}
	}
}
