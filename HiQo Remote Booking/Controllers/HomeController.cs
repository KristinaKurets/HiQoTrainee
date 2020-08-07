using Microsoft.AspNetCore.Mvc;
using Service.AdminService.Interfaces;
using Service.BookingService.Interfaces;

namespace HiQo_Remote_Booking.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAdminService _service;

        public HomeController(IAdminService adminService, IBookingManagementService service)
        {
            _service = adminService;
            var list = _service.GetUsers();
            var desk = list[0].Desk;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
