﻿using RestaurantApp.EntityLayer.Entities;

namespace RestaurantApp.BusinessLayer.Abstracts
{
    public interface IBookingService : IGenericService<Booking>
    {
        void BookingStatusApproved(int id);
        void BookingStatusCancelled(int id);

	}
    
}
