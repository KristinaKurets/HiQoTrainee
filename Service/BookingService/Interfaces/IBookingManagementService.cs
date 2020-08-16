﻿using System;


namespace Service.BookingService.Interfaces
{
    public interface IBookingManagementService
    {

       
        public bool CreateBooking(int userID, int descID, DateTime time);
        public bool СancelBooking(int userID, long orderID);
    }
}
