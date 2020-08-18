using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DB.EntityStatus;
using DtoCommon.BookingDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.BookingService.Interfaces;

namespace HiQo_Remote_Booking.Controllers.BookingControllers
{
    
    [Controller]
    public class DeskAvailabilityController : Controller
    {
        private readonly IDeskAvailabilityService _deskAvailabilityService;
        private readonly IMapper _mapper;

        public DeskAvailabilityController(IDeskAvailabilityService deskAvailabilityService, IMapper mapper)
        {
            _deskAvailabilityService = deskAvailabilityService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetDeskAvailability(DateTime date)
        {
            return Json(_mapper.Map<BookingDeskDTO>(_deskAvailabilityService.GetDeskAvailability(date)));
        }

        [HttpGet]
        public IActionResult GetDeskAvailabilityDeskStatus(DateTime date, DeskStatus deskStatus)
        {
            return Json(_mapper.Map<BookingDeskDTO>(_deskAvailabilityService.GetDeskAvailability(date, deskStatus)));
        }
    }
}
