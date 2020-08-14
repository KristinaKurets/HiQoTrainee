using AutoMapper;
using DB.Entity;
using DB.LookupTable;
using DtoCommon.DTO.Entities;
using DtoCommon.DTO.LookUps;

namespace Profiles
{
    public class DtoProfile:Profile
    {
        public DtoProfile()
        {
            CreateMap<BookingStatusLookup, BookingStatusLookUpDto>().ReverseMap();
            CreateMap<Desk, DeskDto>()
                .ForMember(dst => dst.User, src => src.MapFrom(s => s.User))
                .ForMember(dst => dst.Room, src => src.MapFrom(s => s.Room));
            CreateMap<DeskStatusLookup, DeskStatusLookUpDto>().ReverseMap();
            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<Room, RoomDto>().ReverseMap();
            CreateMap<UserPosition, UserPositionDto>().ReverseMap();
            CreateMap<User, UserDto>()
                .ForMember(dst=>dst.Position, src=>src.MapFrom(s=>s.Position))
                .ForMember(dst=>dst.Room, src=>src.MapFrom(s=>s.Room))
                .ForMember(dst=>dst.Desk, src=> src.MapFrom(s=>s.Desk))
                .ForMember(dst=>dst.WorkPlan, src=>src.MapFrom(s=>s.WorkPlan));
            CreateMap<UserRoleLookup, UserRoleLookUpDto>().ReverseMap();
            CreateMap<WorkingDaysCalendar, WorkingDaysCalendarDto>().ReverseMap();
            CreateMap<WorkPlan, WorkPlanDto>().ReverseMap();
            CreateMap<DeskDto, Desk>()
                .ForMember(dst => dst.User, src => src.MapFrom((s => s.User)))
                .ForMember(dst => dst.Room, src => src.MapFrom(s => s.Room));
            CreateMap<UserDto, User>()
                .ForMember(dst=>dst.Position, src=>src.MapFrom(s=>s.Position))
                .ForMember(dst => dst.Room, src => src.MapFrom(s => s.Room))
                .ForMember(dst => dst.Desk, src => src.MapFrom(s => s.Desk))
                .ForMember(dst => dst.WorkPlan, src => src.MapFrom(s => s.WorkPlan));
        }
    }
}