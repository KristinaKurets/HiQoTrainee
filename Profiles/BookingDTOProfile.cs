using AutoMapper;
using DB.Entity;
using DtoCommon.DTO.EntitiesStatuses;
using DtoCommon.BookingDTO;
using DtoCommon.BookingDTO.Status;

namespace Profiles
{
   public  class BookingDTOProfile: Profile
    {
        public BookingDTOProfile() {
            CreateMap<Room, BookingRoomDTO>()
                .ForMember(dst=>dst.Id,src=>src.MapFrom(x=>x.Id))
                .ForMember(dst => dst.Title, src => src.MapFrom(x => x.Title))
                .ForMember(dst => dst.MaxEmployees, src => src.MapFrom(x => x.MaxEmployees))
                .ForMember(dst => dst.Floor, src => src.MapFrom(x => x.Floor));
            CreateMap<User, BookingUserDTO>()
                .ForMember(dst => dst.Id, src => src.MapFrom(x => x.Id))
                .ForMember(dst => dst.FirstName, src => src.MapFrom(x => x.FirstName))
                .ForMember(dst => dst.LastName, src => src.MapFrom(x => x.LastName));
            CreateMap<Desk, BookingDeskDTO>()
                .ForMember(dst => dst.Id, src => src.MapFrom(x => x.Id))
                .ForMember(dst => dst.Status, src => src.MapFrom(x => (DeskStatusDTO)x.Status))
                .ForMember(dst => dst.MacBook, src => src.MapFrom(x => x.MacBook))
                .ForMember(dst => dst.Headset, src => src.MapFrom(x => x.Headset))
                .ForMember(dst => dst.Camera, src => src.MapFrom(x => x.Camera))
                .ForMember(dst => dst.User, src => src.MapFrom(x => x.User))
                .ForMember(dst => dst.Room, src => src.MapFrom(x => x.Room))
                .ForMember(dst => dst.Title, src => src.MapFrom(x => x.Title)); 
            CreateMap<Order, BookingOrderDTO>()
                .ForMember(dst => dst.Id, src => src.MapFrom(x => x.Id))
                .ForMember(dst => dst.Status, src => src.MapFrom(x => (BookingStatusDTO)x.Status))
                .ForMember(dst => dst.DateTime, src => src.MapFrom(x => x.DateTime))
                .ForMember(dst => dst.User, src => src.MapFrom(x => x.User))
                .ForMember(dst => dst.Desk, src => src.MapFrom(x => x.Desk));

        }

    }
}
