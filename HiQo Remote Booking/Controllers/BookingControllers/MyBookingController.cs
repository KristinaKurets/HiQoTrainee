using System;
using AutoMapper;
using DtoCommon.BookingDTO;
using Microsoft.AspNetCore.Mvc;
using Service.BookingService.Interfaces;

namespace HiQo_Remote_Booking.Controllers
{
    public class MyBookingController : Controller
    {
        private readonly IMyBookingsService _myBookingsService;
        private readonly IMapper _mapper;

        public MyBookingController(IMyBookingsService myBookingsService, IMapper mapper)
        {
            _myBookingsService = myBookingsService;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult ActualBooking(BookingUserDTO user)
        {
            return Json(_mapper.Map<BookingOrderDTO>(_myBookingsService.GetActiveBookings(user.Id)));
        }

        [HttpPost]
        public IActionResult ExpiredBooking(BookingUserDTO user, DateTime startTime, DateTime endTime)
        {
            return Json(_mapper.Map<BookingOrderDTO>(_myBookingsService.GetBookingsHistory(user.Id, startTime, endTime)));
        }
    }
}
