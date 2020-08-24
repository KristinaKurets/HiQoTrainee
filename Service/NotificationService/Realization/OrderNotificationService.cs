using DB.Entity;
using EmailService.Entities;
using EmailService.Interfaces;
using HiQoKerioConnectCalendarApiClient.Entities.Extensions;
using HiQoKerioConnectCalendarApiClient.Interfaces;
using Service.NotificationService.Interfaces;


namespace Service.NotificationService.Realization
{
    public class OrderNotificationService:IOrderNotification
    {
        private readonly IEmailService EmailService;
        private readonly ICalendrAPIClient CalendrAPIClient;

        public OrderNotificationService( IEmailService emailService, ICalendrAPIClient calendrAPIClient) {   
            EmailService = emailService;
            CalendrAPIClient = calendrAPIClient;
        }

        protected void SendEmailСonfirmation(Order order, User user) {
            var Event = new CalendarEventEntity()
            {
                Summary = $"Booking the desk {order.Desk.Title}.",
                Start = order.DateTime.Date.AddHours(+10),
                End = order.DateTime.Date.AddHours(+18),
                Location = $"Desk located on the {order.Desk.Room.Floor} floor in the {order.Desk.RoomId} room."
            };
            EmailService.SendСonfirmation(user.Email, Event);
        }

        protected void SendOrderToCalendar(Order order) {
            CalendrAPIClient.CreateEvent(new HiQoKerioConnectCalendarApiClient.Entities.Event().Initialize(order));
        }
        public void BookingConfirmed(Order order)
        {
            User user = order.User;
            if (user.BookingConfirmationNotification) {
                SendEmailСonfirmation(order, user);
            }
            if (user.СalendarSyncNotification) {
                SendOrderToCalendar(order);
            }
        }
    }
}
