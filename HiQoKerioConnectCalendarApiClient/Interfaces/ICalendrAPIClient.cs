using HiQoKerioConnectCalendarApiClient.Entities;

namespace HiQoKerioConnectCalendarApiClient.Interfaces
{
    public interface ICalendrAPIClient
    {
        public string CreateEvent(Event calendarEvent);
    }
}
