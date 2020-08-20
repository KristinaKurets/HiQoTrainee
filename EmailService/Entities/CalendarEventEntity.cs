using System;
using System.Collections.Generic;
using System.Text;

namespace EmailService.Entities
{
   public  class CalendarEventEntity
    {
        public string Description { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Location { get; set; }

        public string ToICS() {
            StringBuilder ICS = new StringBuilder();
            string DateFormat = "yyyyMMddTHHmmssZ";
            ICS.AppendLine("BEGIN:VCALENDAR");
            ICS.AppendLine("PRODID:-//Compnay Inc//Product Application//EN");
            ICS.AppendLine("VERSION:2.0");
            ICS.AppendLine("METHOD:PUBLISH");
            {
                string now = DateTime.Now.ToUniversalTime().ToString(DateFormat);
                ICS.AppendLine("BEGIN:VEVENT");
                ICS.AppendLine("DTSTART:" + Start.ToUniversalTime().ToString(DateFormat));
                ICS.AppendLine("DTEND:" + End.ToUniversalTime().ToString(DateFormat));
                ICS.AppendLine("DTSTAMP:" + now);
                ICS.AppendLine("UID:" + Guid.NewGuid());
                ICS.AppendLine("CREATED:" + now);
                ICS.AppendLine("LAST-MODIFIED:" + now);
                ICS.AppendLine("LOCATION:" + Location);
                ICS.AppendLine("SEQUENCE:0");
                ICS.AppendLine("STATUS:CONFIRMED");
                ICS.AppendLine("SUMMARY:" + Description);
                /*
                 * Нужно деделать 
                ICS.AppendLine("ORGANIZER:" + "");
                */
                ICS.AppendLine("TRANSP:OPAQUE");
                ICS.AppendLine("END:VEVENT");
            }
            ICS.AppendLine("END:VCALENDAR");
            return ICS.ToString();
        }
    }
}
