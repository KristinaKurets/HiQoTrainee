using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DtoCommon.BookingDTO;
using Microsoft.AspNetCore.Mvc;
using Service.BookingService.Interfaces;

namespace HiQo_Remote_Booking.Controllers.BookingControllers
{
    public class BookingManagementController : Controller
    {
        private readonly IBookingManagementService _bookingManagementService;

        public BookingManagementController(IBookingManagementService bookingManagementService)
        {
            _bookingManagementService = bookingManagementService;
        }

        [HttpGet]
        public IActionResult CreateBooking(int userId, int deskId, DateTime time)
        {
            return Json(_bookingManagementService.CreateBooking(userId, deskId, time));
        }

        [HttpGet]
        public IActionResult CancelBooking(int userId, int orderId)
        {
            return Json(_bookingManagementService.CancelBooking(userId, orderId));
        }
    }
}
