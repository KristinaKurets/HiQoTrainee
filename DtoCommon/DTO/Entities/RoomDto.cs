using System.ComponentModel.DataAnnotations.Schema;
using DB.Entity;

namespace DtoCommon.DTO.Entities
{
    public class RoomDto
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public short MaxEmployees { get; set; }
        public short Floor { get; set; }
        public int? BookingInfoId { get; set; }

        public static implicit operator RoomDto(Room room)
        {
            return new RoomDto()
            {
                Id = room.Id,
                BookingInfoId = room.BookingInfoId,
                Floor = room.Floor,
                MaxEmployees = room.MaxEmployees,
                Title = room.Title
            };
        }

        public static explicit operator Room(RoomDto room)
        {
            return new Room()
            {
                BookingInfoId = room.BookingInfoId,
                Floor = room.Floor,
                MaxEmployees = room.MaxEmployees,
                Title = room.Title
            };
        }
    }
}