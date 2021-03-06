﻿using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.BookingService.Interfaces;

namespace HiQo_Remote_Booking.Controllers.BookingControllers
{
    /// <summary>
    /// Class-controller for booking actions.
    /// </summary>
    [ApiController]
    [AllowAnonymous]
    [Route("[controller]")]
    public class BookingManagementController : Controller
    {
        private readonly IBookingManagementService _bookingManagementService;

        public BookingManagementController(IBookingManagementService bookingManagementService)
        {
            _bookingManagementService = bookingManagementService;
        }

        /// <summary>
        /// Creating of booking.
        /// </summary>
        /// <param name="userId">The unique User ID.</param>
        /// <param name="deskId">The unique Desk ID.</param>
        /// <param name="time">Time for booking.</param>
        /// <returns>A bool containing the information about creating of booking.</returns>
        [HttpPost]
        [Route("/booking/management/create")]
        public IActionResult CreateBooking(int userId, int deskId, DateTime time)
        {
            return Json(_bookingManagementService.CreateBooking(userId, deskId, time));
        }

        /// <summary>
        /// Cancelling of booking.
        /// </summary>
        /// <param name="userId">The unique User ID.</param>
        /// <param name="orderId">The unique Order ID.</param>
        /// <returns>A bool containing the information about cancelling of booking</returns>
        [HttpPost]
        [Route("/booking/management/delete")]
        public IActionResult CancelBooking(int userId, int orderId)
        {
            return Json(_bookingManagementService.CancelBooking(userId, orderId));
        }
    }
}
