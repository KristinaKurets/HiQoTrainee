using System;
using Microsoft.AspNetCore.Mvc;
using Service.BookingService.DTO;
using Service.BookingService.Interfaces;

namespace HiQo_Remote_Booking.Controllers
{
    public class MyBookingController : Controller
    {
        private readonly IMyBookingsService _myBookingsService;

        public MyBookingController(IMyBookingsService myBookingsService)
        {
            _myBookingsService = myBookingsService;
        }
        [HttpPost]
        public JsonResult ActualBooking(BookingUserDTO user)
        {
            return Json(_myBookingsService.GetActiveBookings(user));
        }
        [HttpPost]
        public JsonResult ExpiredBooking(BookingUserDTO user, DateTime startTime, DateTime endTime)
        {
            return Json(_myBookingsService.GetBookingsHistory(user, startTime, endTime));
        }
    }
}
