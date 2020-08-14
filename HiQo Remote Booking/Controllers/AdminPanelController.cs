using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Service.AdminService.Interfaces;

namespace HiQo_Remote_Booking.Controllers
{
    [Controller]
    public class AdminPanelController : Controller
    {
        private readonly IAdminService _adminService;

        public AdminPanelController(IAdminService service)
        {
            _adminService = service;
        }
        [HttpGet]
        public JsonResult NewComers()
        {
            return Json(_adminService.GetUsers().Where(u=>u.Room==null));
        }
        [HttpGet]
        public JsonResult AllUsers()
        {
            return Json(_adminService.GetUsers());
        }
    }
}
