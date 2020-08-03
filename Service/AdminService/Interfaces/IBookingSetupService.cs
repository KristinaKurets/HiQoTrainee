using System.Linq;
using Service.AdminService.DTO.Entities;

namespace Service.AdminService.Interfaces
{
    public interface IBookingSetupService
    {
        IQueryable<BookingInfoDto> Create(BookingInfoDto booking);
        IQueryable<BookingInfoDto> Update(BookingInfoDto booking);
        IQueryable<BookingInfoDto> Delete(BookingInfoDto booking);
        BookingInfoDto Read(RoomDto room);
    }
}