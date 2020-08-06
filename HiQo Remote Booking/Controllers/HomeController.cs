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

        public HomeController(IMapper mapper, HqrbContext context)
        {
            IUnitOfWork unitOfWork = new UnitOfWork(context);
            _service=new AdminService(unitOfWork, mapper);
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
