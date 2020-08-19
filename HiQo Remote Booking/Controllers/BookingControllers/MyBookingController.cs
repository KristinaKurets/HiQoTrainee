using System;
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
        /// Gets information about actual bookings of a specific user.
        /// </summary>
        /// <param name="user">Short infotmation about user, who made the booking</param>
        /// <returns>List of actual bookings of a specific user.</returns>
        [HttpGet]
        [Route("/booking/actual")]
        public IActionResult ActualBooking(BookingUserDTO user)
        {
            return Json(_mapper.Map<BookingOrderDTO>(_myBookingsService.GetActiveBookings(user.Id)));
        }
        /// <summary>
        /// Gets information about expired bookings of a specific user.
        /// </summary>
        /// <param name="user">Short infotmation about user, who made the booking</param>
        /// <param name="startTime">Start date of sampling period.</param>
        /// <param name="endTime">End date of sampling period.</param>
        /// <returns>List of expired bookings of a specific user.</returns>
        [HttpGet]
        [Route("/booking/expired")]
        public IActionResult ExpiredBooking(BookingUserDTO user, DateTime startTime, DateTime endTime)
        {
            return Json(_mapper.Map<BookingOrderDTO>(_myBookingsService.GetBookingsHistory(user.Id, startTime, endTime)));
        }
    }
}
