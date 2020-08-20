using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DB.EntityStatus;
using DtoCommon.BookingDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Service.BookingService.Interfaces;

namespace HiQo_Remote_Booking.Controllers.BookingControllers
{
    /// <summary>
    /// Class-controller for getting information about availability of desks.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class DeskAvailabilityController : Controller
    {
        private readonly IDeskAvailabilityService _deskAvailabilityService;
        private readonly IMapper _mapper;

        public DeskAvailabilityController(IDeskAvailabilityService deskAvailabilityService, IMapper mapper)
        {
            _deskAvailabilityService = deskAvailabilityService;
            _mapper = mapper;
        }

        /// <summary>
        /// Gets all available desks.
        /// </summary>
        /// <param name="date">Sampling date.</param>
        /// <returns>List of all available desks. </returns>
        [HttpGet]
        [Route("/desks/available/{date}")]
        public IActionResult GetDeskAvailability(DateTime date)
        {
            return Json(_mapper.Map<BookingDeskDTO>(_deskAvailabilityService.GetDeskAvailability(date)));
        }

        /// <summary>
        /// Gets all available desks by status.
        /// </summary>
        /// <param name="date">Sampling date.</param>
        /// <param name="deskStatus">Sampling status.</param>
        /// <returns>List of all available desks by needed status.</returns>
        [HttpGet]
        [Route("desks/available/{date}/{deskStatus}")]
        public IActionResult GetDeskAvailabilityDeskStatus(DateTime date, DeskStatus deskStatus)
        {
            return Json(_mapper.Map<BookingDeskDTO>(_deskAvailabilityService.GetDeskAvailability(date, deskStatus)));
        }
    }
}
