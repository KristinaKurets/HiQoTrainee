using System.Collections.Generic;
using DB.Entity;

namespace Service.AdminService.DTO.Entities
{
    public class RoomDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public short MaxEmployees { get; set; }
        public short Floor { get; set; }
        public BookingInfoDto BookingInfo { get; set; }

        public static implicit operator RoomDto(Room room)
        {
            return new RoomDto()
            {
                Id = room.Id,
                BookingInfo = room.BookingInfo,
                Floor = room.Floor,
                MaxEmployees = room.MaxEmployees,
                Title = room.Title
            };
        }

        public static explicit operator Room(RoomDto room)
        {
            return new Room()
            {
                Id = room.Id,
                BookingInfo = (BookingInfo) room.BookingInfo,
                Floor = room.Floor,
                MaxEmployees = room.MaxEmployees,
                Title = room.Title
            };
        }
    }
}