using System;
using DB.Entity;

namespace Service.AdminService.DTO.Entities
{
    public class BookingInfoDto
    {
        public int Id { get; set; }
        public TimeSpan TimeOpenForBooking { get; set; }
        public TimeSpan TimeCloseForBooking { get; set; }
        public int DaysOpenForBooking { get; set; }

        public int DaysCloseForBooking { get; set; }

        public static implicit operator BookingInfoDto(BookingInfo bookingInfo)
        {
            return new BookingInfoDto()
            {
                DaysCloseForBooking = bookingInfo.DaysCloseForBooking,
                DaysOpenForBooking = bookingInfo.DaysOpenForBooking,
                TimeCloseForBooking = bookingInfo.TimeCloseForBooking,
                TimeOpenForBooking = bookingInfo.TimeOpenForBooking,
                Id = bookingInfo.Id
            };
        }

        public static explicit operator BookingInfo(BookingInfoDto bookingInfoDto)
        {
            return new BookingInfo()
            {
                TimeCloseForBooking = bookingInfoDto.TimeCloseForBooking,
                TimeOpenForBooking = bookingInfoDto.TimeOpenForBooking,
                DaysCloseForBooking = bookingInfoDto.DaysCloseForBooking,
                DaysOpenForBooking = bookingInfoDto.DaysOpenForBooking,
            };
        }
    }
}