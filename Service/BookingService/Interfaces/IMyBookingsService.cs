using Service.BookingService.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.BookingService.Interfaces
{
    public interface IMyBookingsService
    {

        public IEnumerable<BookingOrderDTO> GetActiveBookings(BookingUserDTO user);
        public IEnumerable<BookingOrderDTO> GetBookingsHistory(BookingUserDTO user,DateTime start, DateTime end);
    }
}
