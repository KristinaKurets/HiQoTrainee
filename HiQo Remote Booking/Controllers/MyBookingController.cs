using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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

        public IActionResult ActualBooking(int userID)
        {
           return Json( myBookingsService.GetActiveBookings(userID));
            
        }

        public IActionResult ExpiredBooking(int userID, DateTime startTime, DateTime endTime)
        {
           return Json(myBookingsService.GetBookingsHistory(userID, startTime, endTime));
        }
    }
}
