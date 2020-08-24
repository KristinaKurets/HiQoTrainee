using EmailService.Entities;
using EmailService.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace EmailService.Service
{
    public class EmailService:IEmailService
    {
        protected SmtpClient _client;
        protected const string myEmail = "dev_email_v11@mail.ru";
        protected const string displayName = "Your favourite service";
        protected const string password = "koMAnser28317";

        public EmailService() {
            // настроено на почту маил ру, нужно настроить на нормальную и вынести в ресурсы
            _client = new SmtpClient("smtp.mail.ru", 25);
            _client.Credentials = new NetworkCredential(myEmail, password);
            _client.EnableSsl = true;
        }
        protected void Send(MailMessage mailMessage) {
           _client.Send(mailMessage);
        }

        public async void SendСonfirmation(string to, CalendarEventEntity eventInfo) {
            MailMessage message = new MailMessage();
            message.To.Add(to);
            // Тоже нужно под нормальную почту настраивать и выносить константы
            message.From = new MailAddress(myEmail, displayName);
            message.Subject = "Notification";
            message.Body = "Dear user, information about your booking is in the attached ics file.";
            message.IsBodyHtml = true;
            MemoryStream EventICS = new MemoryStream(Encoding.UTF8.GetBytes(eventInfo.ToICS()));
            Attachment attachment = new Attachment(EventICS, "event.ics", "text/calendar");
            message.Attachments.Add(attachment);
            await Task.Run(()=>Send(message));
        } 
    }
}
