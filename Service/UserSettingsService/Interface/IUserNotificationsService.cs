using System;
using System.Collections.Generic;
using System.Text;

namespace Service.UserNotificationsService.Interface
{
    public interface IUserNotificationsService
    {
        public bool CancellationNotification(int userID, bool flag);
        public bool ConfirmationNotification(int userID, bool flag);
        public bool CalendarSyncNotification(int userID, bool flag);

    }
}
