using DB.Entity;
using DB.EntityStatus;
using System;
using System.Collections.Generic;

namespace Service.BookingService.Interfaces
{
    public interface IDeskAvailabilityService
    {
        IEnumerable<Desk> GetDeskAvailability(DateTime dateTime);
        IEnumerable<Desk> GetDeskAvailability(DateTime dateTime, DeskStatus status);
    }
}
