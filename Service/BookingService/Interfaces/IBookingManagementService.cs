using DB.Entity;
using Service.BookingService.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.BookingService.Interfaces
{
    public interface IBookingManagementService
    {

       
        public bool CreateBooking(BookingUserDTO user, BookingDeskDTO desc, DateTime time);
        public bool СancelBooking(BookingUserDTO user,long orderID);
    }
}
