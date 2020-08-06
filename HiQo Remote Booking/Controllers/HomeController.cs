using AutoMapper;
using DB.Context;
using Microsoft.AspNetCore.Mvc;
using Repository.UnitOfWork;
using Service.AdminService.Interfaces;
using Service.AdminService.Services;

namespace HiQo_Remote_Booking.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAdminService _service;

        public HomeController(IMapper mapper, IUnitOfWork unit)
        {
            _service=new AdminService(unit, mapper);
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
