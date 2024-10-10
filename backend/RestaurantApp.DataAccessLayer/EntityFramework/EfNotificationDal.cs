using RestaurantApp.DataAccessLayer.Abstracts;
using RestaurantApp.DataAccessLayer.Concretes;
using RestaurantApp.DataAccessLayer.Repositories;
using RestaurantApp.EntityLayer.Entities;

namespace RestaurantApp.DataAccessLayer.EntityFramework
{
	public class EfNotificationDal : GenericRepository<Notification>, INotificationDal
	{
		public EfNotificationDal(SignalRContext context) : base(context)
		{
		}

		public List<Notification> GetAllNotificationsByFalse()
		{
			using (var context = new SignalRContext())
			{
				return context.Notifications.Where(x => x.Status == false).ToList();
			}
		}

		public int NotificationCountByStatusFalse()
		{
			using(var context = new SignalRContext())
			{
				return context.Notifications.Where(x => x.Status == false).Count();
			}
		}
	}
}
