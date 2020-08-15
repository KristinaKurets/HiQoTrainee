using DB.Entity;

namespace Service.AdminService.Changers
{
    public static class BookingInfoChanger
    {
        public static BookingInfo ChangeFromDto(BookingInfo booking, BookingInfo source)
        {
            booking.DaysCloseForBooking = source.DaysCloseForBooking;
            booking.DaysOpenForBooking = source.DaysOpenForBooking;
            booking.TimeCloseForBooking = source.TimeCloseForBooking;
            booking.TimeOpenForBooking = source.TimeOpenForBooking;
            return booking;
        }
    }
}