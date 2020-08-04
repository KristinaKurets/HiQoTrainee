using System.Collections.Generic;
using System.Linq;
using Service.AdminService.DTO.Entities;

namespace Service.AdminService.Interfaces
{
    public interface IBookingSetupService
    {
        List<BookingInfoDto> Create(BookingInfoDto booking);
        List<BookingInfoDto> Update(BookingInfoDto booking);
        List<BookingInfoDto> Delete(BookingInfoDto booking);
        BookingInfoDto Read(RoomDto room);
    }
}