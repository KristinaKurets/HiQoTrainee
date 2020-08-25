using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.UserNotificationsService.Interface;

namespace HiQo_Remote_Booking.Controllers
{
    /// <summary>
    /// Controller for configuring user notifications
    /// </summary>
    [ApiController]
    [AllowAnonymous]
    [Route("[controller]")]
    public class UserNotificationsController : Controller
    {
        private readonly IUserNotificationsService _userNotificationsService;
        public UserNotificationsController(IUserNotificationsService userNotificationsService)
        {
            _userNotificationsService = userNotificationsService;
        }
       
        /// <summary>
        /// Сonfiguring calendar sync notifications.
        /// </summary>
        /// <param name="userId">The unique User ID.</param>
        /// <param name="flag">On/off notifications.</param>
        /// <returns>A bool containing the information about flag of notifications.</returns>
        [HttpPost]
        [Route("user/settings/notifications/calendarSync")]
        public IActionResult SetCalendarSyncNotifications(int userId, bool flag)
        {
            return Json(_userNotificationsService.CalendarSyncNotification(userId,flag));
        }
       
        /// <summary>
        /// Сonfiguring cancellation booking notifications.
        /// </summary>
        /// <param name="userId">The unique User ID.<</param>
        /// <param name="flag">On/off notifications.</param>
        /// <returns>A bool containing the information about flag of notifications.</returns>
        [HttpPost]
        [Route("user/settings/notifications/cancellation")]
        public IActionResult SetCancellationNotification(int userId, bool flag)
        {
            return Json(_userNotificationsService.CancellationNotification(userId, flag));
        }

        /// <summary>
        /// Сonfiguring confirmation booking notifications.
        /// </summary>
        /// <param name="userId">The unique User ID.</param>
        /// <param name="flag">On/off notifications.</param>
        /// <returns>A bool containing the information about flag of notifications.</returns>
       [HttpPost]
       [Route("user/settings/notifications/confirmation")]
        public IActionResult SetConfirmationNotification(int userId, bool flag)
        {
            return Json(_userNotificationsService.ConfirmationNotification(userId, flag));
        }
    }
}
