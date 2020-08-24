using EmailService.Entities;

namespace EmailService.Interfaces
{
    public interface IEmailService
    {
        public void SendСonfirmation(string to, CalendarEventEntity eventInfo);
    }
}
