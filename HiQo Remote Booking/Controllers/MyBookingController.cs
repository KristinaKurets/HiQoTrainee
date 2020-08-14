using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Service.BookingService.DTO;
using Service.BookingService.Interfaces;

namespace HiQo_Remote_Booking.Controllers
{
    public class MyBookingController : Controller
    {
        private IMyBookingsService myBookingsService;

        public MyBookingController(IMyBookingsService myBookingsService)
        {
            this.myBookingsService = myBookingsService;
        }

        public IActionResult ActualBooking(BookingUserDTO user)
        {
            var bookingList = myBookingsService.GetActiveBookings(user);
            return View();
        }

        public IActionResult ExpiredBooking(BookingUserDTO user, DateTime startTime, DateTime endTime)
        {
            var bookingList = myBookingsService.GetBookingsHistory(user, startTime, endTime);
            return View();
        }
    }
}
