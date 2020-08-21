using DB.Entity;
using EmailService.Entities;
using EmailService.Interfaces;
using Repository.UnitOfWork;
using Service.NotificationService.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;

namespace Service.NotificationService.Realization
{
    public class OrderNotificationService:IOrderNotification
    {
        private IUnitOfWork DataBase;
        private IEmailService EmailService;

        public OrderNotificationService(IUnitOfWork unitOfWork, IEmailService emailService) {
            DataBase = unitOfWork;
            EmailService = emailService;
        }

        protected void SendEmailСonfirmation(Order order,User user) {
            var Event = new CalendarEventEntity()
            {
                Summary = "",
                Start = new DateTime(),
                End = new DateTime(),
                Location = ""
            };
            EmailService.SendСonfirmation(user.Email, Event);
        }
        public void BookingConfirmed(Order order)
        {
            User user = DataBase.UserRepository.Read(order.UserId);
            if (user.BookingConfirmationNotification) {
                SendEmailСonfirmation(order, user);
            }
        }
    }
}
