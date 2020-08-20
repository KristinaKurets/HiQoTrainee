using System;
using System.Collections.Generic;
using System.Text;

namespace Service.UserNotificationsService.Interface
{
    public interface IUserNotificationsService
    {
        public bool CancellationNotificationOn(int userID);
        public bool ConfirmationNotificationOn(int userID);
        public bool CalendarSyncNotificationOn(int userID);
        public bool CancellationNotificationOff(int userID);
        public bool ConfirmationNotificationOff(int userID);
        public bool CalendarSyncNotificationOff(int userID);
    }
}
