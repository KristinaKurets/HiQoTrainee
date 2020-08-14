using AutoMapper;
using DB.Context;
using Microsoft.AspNetCore.Mvc;
using Repository.UnitOfWork;
using Service.AdminService.Interfaces;
using Service.AdminService.Services;
using Service.BookingService.Interfaces;
using System;
using System.Linq;

namespace HiQo_Remote_Booking.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDeskAvailabilityService _service;

        public HomeController(IDeskAvailabilityService service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            return View();
        }


        // тестик фильтра ошибок
        public IActionResult Error()
        {
            var a = 0;
            var b = 7;
            var d = b / a;
            return View();
        }
    }
}
