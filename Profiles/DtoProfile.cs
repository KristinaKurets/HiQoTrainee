using AutoMapper;
using DB.Entity;
using DB.LookupTable;
using DtoCommon.DTO.Entities;
using DtoCommon.DTO.LookUps;
using DtoCommon.DtoForCreating;

namespace Profiles
{
    public class DtoProfile:Profile
    {
        public DtoProfile()
        {
            AllowNullCollections = true;
            CreateMap<BookingStatusLookup, BookingStatusLookUpDto>().ReverseMap();
            CreateMap<Desk, DeskDto>()
                .ForPath(dst => dst.User, src => src.MapFrom(s => s.User))
                .ForMember(dst => dst.Room, src => src.MapFrom(s => s.Room));
            CreateMap<DeskStatusLookup, DeskStatusLookUpDto>().ReverseMap();
            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<Room, RoomDto>().ReverseMap();
            CreateMap<UserPosition, UserPositionDto>().ReverseMap();
            CreateMap<User, UserDto>()
                .ForMember(dst => dst.Position, src => src.MapFrom(s => s.Position))
                .ForPath(dst => dst.Room, src => src.MapFrom(s => s.Room))
                .ForPath(dst => dst.Desk, src => src.MapFrom(s => s.Desk))
                .ForPath(dst => dst.WorkPlan, src => src.MapFrom(s => s.WorkPlan));
            CreateMap<UserRoleLookup, UserRoleLookUpDto>().ReverseMap();
            CreateMap<WorkingDaysCalendar, WorkingDaysCalendarDto>().ReverseMap();
            CreateMap<WorkPlan, WorkPlanDto>().ReverseMap();
            CreateMap<DeskDto, Desk>()
                .ForMember(dst => dst.RoomId, src => src.MapFrom(s => s.Room.Id))
                .ForPath(dst => dst.User, src => src.MapFrom(s => s.User));
            CreateMap<UserDto, User>()
                .ForMember(dst => dst.UserPositionId, src => src.MapFrom(s => s.Position.Id))
                .ForPath(dst => dst.RoomId, src => src.MapFrom(s => s.Room.Id))
                .ForPath(dst => dst.DeskId, src => src.MapFrom(s => s.Desk.Id))
                .ForPath(dst => dst.WorkPlanId, src => src.MapFrom(s => s.WorkPlan.Id));
            CreateMap<int, User>()
                .ForMember(dst => dst.Id, src => src.MapFrom(s => s));
            CreateMap<int, Room>()
                .ForMember(dst => dst.Id, src => src.MapFrom(s => s));
            CreateMap<int, WorkPlan>()
                .ForMember(dst => dst.Id, src => src.MapFrom(s => s));
            CreateMap<int, BookingInfo>()
                .ForMember(dst => dst.Id, src => src.MapFrom(s => s));
            CreateMap<BookingInfoCreatingDto, BookingInfo>()
                .ForMember(dst => dst.TimeOpenForBooking, 
                    src => src.MapFrom(s => s.TimeOpenForBooking.TimeOfDay))
                .ForMember(dst => dst.TimeCloseForBooking, 
                    src => src.MapFrom(s => s.TimeCloseForBooking.TimeOfDay));
        }
    }
}