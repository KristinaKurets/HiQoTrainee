using EmailService.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace EmailService.Service
{
    public class EmailService
    {
        protected SmtpClient _client;
        public EmailService() {
            // настроено на почту маил ру, нужно настроить на нормальную и вынести в ресурсы
            _client = new SmtpClient("smtp.mail.ru", 25);
            _client.Credentials = new NetworkCredential("dev_email_v11@mail.ru", "koMAnser28317");
            _client.EnableSsl = true;
        }
        protected void Send(MailMessage mailMessage) {
           _client.Send(mailMessage);
        }

        public void SendСonfirmation(string to, CalendarEventEntity eventInfo) {
            MailMessage message = new MailMessage();
            message.To.Add(to);
            // Тоже нужно под нормальную почту настраивать и выносить константы
            message.From = new MailAddress("dev_email_v11@mail.ru", "Test");
            message.Subject = "test";
            message.Body ="test";
            message.IsBodyHtml = true;
            MemoryStream EventICS = new MemoryStream(Encoding.UTF8.GetBytes(eventInfo.ToICS()));
            Attachment attachment = new Attachment(EventICS, "event.ics", "text/calendar");
            message.Attachments.Add(attachment);
            Send(message);
        } 
    }
}
