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
        private readonly IBookingManagementService bookingManagementService;

        public BookingManagementController(IBookingManagementService bookingManagementService)
        {
            this.bookingManagementService = bookingManagementService;
        }

        [HttpPost]
        public IActionResult CreateBooking(int userId, int deskId, DateTime time)
        {
            return Json(bookingManagementService.CreateBooking(userId, deskId, time));
        }

        [HttpPost]
        public IActionResult CancelBooking(int userId, int orderId)
        {
            return Json(bookingManagementService.CancelBooking(userId, orderId));
        }
    }
}
