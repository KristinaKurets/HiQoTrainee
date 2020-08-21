using DB.Entity;
using System.Collections.Generic;
using System.Configuration;

namespace HiQoKerioConnectCalendarApiClient.Entities.Extensions
{
    public static class EventExtension
    {
        private static string _folderID= ConfigurationManager.AppSettings["FOLDER_ID"];
        public static Event Initialize(this Event calendarEvent,Order order) {
            calendarEvent.FolderID = _folderID;
            calendarEvent.IsAllDay = false;
            calendarEvent.IsPrivate = false;
            calendarEvent.Attendees = new List<Attendee>();
            calendarEvent.Attendees.Add(new Attendee().InitializeOrganizer());
            calendarEvent.Attendees.Add(new Attendee().Initialize(order.User));
            calendarEvent.Summary = "Booking the desk: " + order.Desk.Title;
            calendarEvent.Description = "Desk located on the " + order.Desk.Room.Floor 
                + " floor in the " + order.Desk.Room.Title + " room.";
            calendarEvent.Start = order.DateTime.AddHours(10);
            calendarEvent.End = order.DateTime.AddHours(18);
            return calendarEvent;
        }
    }
}
