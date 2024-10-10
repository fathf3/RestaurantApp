using RestaurantApp.EntityLayer.Entities;

namespace RestaurantApp.BusinessLayer.Abstracts
{
	public interface INotificationService : IGenericService<Notification>
	{
		int NotificationCountByStatusFalse();
		List<Notification> GetAllNotificationsByFalse();
	}

}
