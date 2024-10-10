using AutoMapper;
using RestaurantApp.DtoLayer.NotificationDto;
using RestaurantApp.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.BusinessLayer.AutoMapper
{
	public class NotificationMapping : Profile
	{
		public NotificationMapping()
		{
			CreateMap<Notification, ResultNotificationDto>().ReverseMap();
			CreateMap<Notification, CreateNotificationDto>().ReverseMap();
			CreateMap<Notification, UpdateNotificationDto>().ReverseMap();
			CreateMap<Notification, GetNotificationDto>().ReverseMap();
		}
	}
}
