using DB.Entity;
using Repository.UnitOfWork;
using Service.UserNotificationsService.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.UserNotificationsService.Realization
{
    public class UserNotificationsService : IUserNotificationsService
    {
        protected readonly IUnitOfWork UnitOfWork;
        public UserNotificationsService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
        
        public bool CalendarSyncNotification(int userID, bool flag)
        {
            User user = UnitOfWork.UserRepository.Read(userID);
            if (user != null)
            {
                user.СalendarSyncNotification = flag;
                UnitOfWork.UserRepository.Update(user);
                UnitOfWork.Save();
                return true;
            }
            return false;
        }

        public bool CancellationNotification(int userID, bool flag)
        {
            User user = UnitOfWork.UserRepository.Read(userID);
            if (user != null)
            {
                user.BookingCancellationNotification = flag;
                UnitOfWork.UserRepository.Update(user);
                UnitOfWork.Save();
                return true;
            }
            return false;
        }

        public bool ConfirmationNotification(int userID, bool flag)
        {
            User user = UnitOfWork.UserRepository.Read(userID);
            if (user != null)
            {
                user.BookingConfirmationNotification = flag;
                UnitOfWork.UserRepository.Update(user);
                UnitOfWork.Save();
                return true;
            }
            return false;
        }
    }
}
