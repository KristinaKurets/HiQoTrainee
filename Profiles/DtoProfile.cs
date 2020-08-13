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
            CreateMap<Desk, DeskDto>()
                .ForMember(dst => dst.User, src => src.MapFrom(s => s.User))
                .ForMember(dst => dst.Room, src => src.MapFrom(s => s.Room));
            CreateMap<DeskStatusLookup, DeskStatusLookUpDto>();
            CreateMap<Order, OrderDto>();
            CreateMap<Room, RoomDto>();
            CreateMap<UserPosition, UserPositionDto>();
            CreateMap<User, UserDto>()
                .ForMember(dst=>dst.Position, src=>src.MapFrom(s=>s.Position))
                .ForMember(dst=>dst.Room, src=>src.MapFrom(s=>s.Room))
                .ForMember(dst=>dst.Desk, src=> src.MapFrom(s=>s.Desk))
                .ForMember(dst=>dst.WorkPlan, src=>src.MapFrom(s=>s.WorkPlan));
            CreateMap<UserRoleLookup, UserRoleLookUpDto>();
            CreateMap<WorkingDaysCalendar, WorkingDaysCalendarDto>();
            CreateMap<WorkPlan, WorkPlanDto>();
        }
    }
}