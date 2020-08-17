using Microsoft.AspNetCore.Mvc;
using Service.AdminService.Interfaces;
using Service.BookingService.Interfaces;


namespace HiQo_Remote_Booking.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDeskAvailabilityService _service;

        public HomeController(IAdminService adminService, IBookingManagementService service)
        {

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
