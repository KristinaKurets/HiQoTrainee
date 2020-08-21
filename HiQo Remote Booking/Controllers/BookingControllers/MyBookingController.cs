using System;
using System.Collections.Generic;
using AutoMapper;
using DtoCommon.BookingDTO;
using Microsoft.AspNetCore.Mvc;
using Service.BookingService.Interfaces;

namespace HiQo_Remote_Booking.Controllers
{
    /// <summary>
    /// Class-controller for getting information about actual and expired bookings.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class MyBookingController : Controller
    {
        private readonly IMyBookingsService _myBookingsService;
        private readonly IMapper _mapper;

        public MyBookingController(IMyBookingsService myBookingsService, IMapper mapper)
        {
            _myBookingsService = myBookingsService;
            _mapper = mapper;
        }
        /// <summary>
        /// Gets information about actual bookings of a specific userId.
        /// </summary>
        /// <param name="userId">Who made the booking</param>
        /// <returns>List of actual bookings of a specific userId.</returns>
        [HttpGet]
        [Route("/booking/actual/{userId}")]
        public IActionResult ActualBooking(int userId)
        {
            return Json(_mapper.Map<List<BookingOrderDTO>>(_myBookingsService.GetActiveBookings(userId)));
        }
        /// <summary>
        /// Gets information about expired bookings of a specific userId.
        /// </summary>
        /// <param name="userId">Who made the booking</param>
        /// <param name="startTime">Start date of sampling period.</param>
        /// <param name="endTime">End date of sampling period.</param>
        /// <returns>List of expired bookings of a specific userId.</returns>
        [HttpGet]
        [Route("/booking/expired/{userId}/{startTime}/{endTime}")]
        public IActionResult ExpiredBooking(int userId, DateTime startTime, DateTime endTime)
        {
            return Json(_mapper.Map<List<BookingOrderDTO>>(_myBookingsService.GetBookingsHistory(userId, startTime, endTime)));
        }
    }
}
