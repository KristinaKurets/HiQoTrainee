using System;
using DtoCommon.BookingDTO;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]
        public IActionResult ActualBooking(BookingUserDTO user)
        {
            return Json(_myBookingsService.GetActiveBookings(user.Id));
        }

        [HttpGet]
        public IActionResult ExpiredBooking(BookingUserDTO user, DateTime startTime, DateTime endTime)
        {
            return Json(_myBookingsService.GetBookingsHistory(user.Id, startTime, endTime));
        }
    }
}
