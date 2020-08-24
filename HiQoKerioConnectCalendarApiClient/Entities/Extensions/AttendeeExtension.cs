using DB.Entity;
using HiQoKerioConnectCalendarApiClient.Configuration;


namespace HiQoKerioConnectCalendarApiClient.Entities.Extensions
{
    public static class AttendeeExtension
    {
        public static Attendee Initialize(this Attendee attendee, User user)
        {
            attendee.DisplayName = user.FirstName+" " + user.LastName;
            attendee.Email = user.Email;
            attendee.Role = "RoleRequiredAttendee";
            attendee.IsNotified = false;
            attendee.PartStatus = "PartAccepted";
            return attendee;
        }

        public static Attendee InitializeOrganizer(this Attendee attendee) {

            attendee.DisplayName = BaseConfiguration.ORG_DISPLAY_NAME;
            attendee.Email = BaseConfiguration.ORG_EMAIL; 
            attendee.Role = "RoleOrganizer";
            attendee.IsNotified = false;
            attendee.PartStatus = "PartAccepted";
            return attendee;
        }
    }
}
