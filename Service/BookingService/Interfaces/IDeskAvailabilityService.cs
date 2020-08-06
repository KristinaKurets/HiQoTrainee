using DB.EntityStatus;
using Service.BookingService.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.BookingService.Interfaces
{
    public interface IDeskAvailabilityService
    {
        IEnumerable<BookingDeskDTO> GetDeskAvailability(DateTime dateTime);
        IEnumerable<BookingDeskDTO> GetDeskAvailability(DateTime dateTime, DeskStatus status);
    }
}
