using System;
using DB.Entity;

namespace DtoCommon.DtoForCreating
{
    public class BookingInfoCreatingDto
    {
        public int Id { get; set; }
        public DateTime TimeOpenForBooking { get; set; }
        public DateTime TimeCloseForBooking { get; set; }
        public int DaysOpenForBooking { get; set; }
        public int DaysCloseForBooking { get; set; }

        public static explicit operator BookingInfo(BookingInfoCreatingDto source)
        {
            return new BookingInfo()
            {
                TimeCloseForBooking = source.TimeCloseForBooking.TimeOfDay,
                TimeOpenForBooking = source.TimeOpenForBooking.TimeOfDay,
                DaysCloseForBooking = source.DaysCloseForBooking,
                DaysOpenForBooking = source.DaysOpenForBooking
            };
        }
    }
}