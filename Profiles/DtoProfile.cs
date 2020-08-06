using AutoMapper;
using DB.Entity;
using DB.LookupTable;
using Service.AdminService.DTO.Entities;
using Service.AdminService.DTO.LookUps;

namespace Profiles
{
    public class DtoProfile:Profile
    {
        public DtoProfile()
        {
            CreateMap<BookingStatusLookup, BookingStatusLookUpDto>();
            CreateMap<Desk, DeskDto>();
            CreateMap<DeskStatusLookup, DeskStatusLookUpDto>();
            CreateMap<Order, OrderDto>();
            CreateMap<Room, RoomDto>();
            CreateMap<UserPosition, UserPositionDto>();
            CreateMap<User, UserDto>();
            CreateMap<UserRoleLookup, UserRoleLookUpDto>();
            CreateMap<WorkingDaysCalendar, WorkingDaysCalendarDto>();
            CreateMap<WorkPlan, WorkPlanDto>();
        }
    }
}