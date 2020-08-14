using DB.Entity;
using DB.EntityStatus;
using DtoCommon.DTO.EntitiesStatuses;

namespace DtoCommon.DTO.Entities
{
    public class DeskDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool MacBook { get; set; }
        public bool Camera { get; set; }
        public bool Headset { get; set; }
        public RoomDto Room { get; set; }
        public DeskStatusDto Status { get; set; }
        public UserDto User { get; set; }

        public static implicit operator DeskDto(Desk desk)
        {
            return new DeskDto()
            {
                Id = desk.Id,
                Title = desk.Title,
                MacBook = desk.MacBook,
                Camera = desk.Camera,
                Headset = desk.Headset,
                Room = desk.Room,
                Status = (DeskStatusDto) desk.Status
            };
        }

        public static explicit operator Desk(DeskDto desk)
        {
            return new Desk()
            {
                Title = desk.Title,
                MacBook = desk.MacBook,
                Camera = desk.Camera,
                Headset = desk.Headset,
                RoomId = desk.Room.Id,
                Status = (DeskStatus) desk.Status
            };
        }
    }
}