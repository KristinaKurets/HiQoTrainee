using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DB.EntityStatus;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.BookingService.Interfaces;

namespace HiQo_Remote_Booking.Controllers.BookingControllers
{
    
    [Controller]
    public class DeskAvailabilityController : Controller
    {
        private readonly IDeskAvailabilityService deskAvailabilityService;

        public DeskAvailabilityController(IDeskAvailabilityService deskAvailabilityService)
        {
            this.deskAvailabilityService = deskAvailabilityService;
        }

        [HttpPost]
        public IActionResult GetDeskAvailability(DateTime date)
        {
            return Json(deskAvailabilityService.GetDeskAvailability(date));
        }

        [HttpPost]
        public IActionResult GetDeskAvailability(DateTime date, DeskStatus deskStatus)
        {
            return Json(deskAvailabilityService.GetDeskAvailability(date, deskStatus));
        }
    }
}
