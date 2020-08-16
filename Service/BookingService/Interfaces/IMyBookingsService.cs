using DB.Entity;
using System;
using System.Collections.Generic;


namespace Service.BookingService.Interfaces
{
    public interface IMyBookingsService
    {

        public IEnumerable<Order> GetActiveBookings(int userID);
        public IEnumerable<Order> GetBookingsHistory(int userID,DateTime start, DateTime end);
    }
}
