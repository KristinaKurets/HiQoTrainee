using DB.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.BookingService.Interfaces
{
    public interface IBookingManagementService
    {
        public bool CreateBooking(User user, Desk desc, DateTime time);
        public bool СancelИooking(User user,long orderID);
    }
}
