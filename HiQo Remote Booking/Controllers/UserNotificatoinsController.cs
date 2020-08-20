using Microsoft.AspNetCore.Mvc;
using Service.UserNotificationsService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HiQo_Remote_Booking.Controllers
{
    /// <summary>
    /// Controller for configuring user notifications
    /// </summary>
    [Controller]
    public class UserNotificatoinsController : Controller
    {
        private readonly IUserNotificationsService _userNotificationsService;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userID">The unique User ID.</param>
        /// <param name="flag">On/off notifications</param>
        /// <returns>A bool containing the information about flag of notifications</returns>
        [HttpGet]
        public IActionResult SetCalendarSyncNotificatios(int userID, bool flag)
        {
            return Json(_userNotificationsService.CalendarSyncNotification(userID,flag));
        }
    }
}
