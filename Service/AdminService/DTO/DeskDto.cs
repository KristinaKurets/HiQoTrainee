using DB.Entity;
using DB.EntityStatus;

namespace Service.AdminService.DTO
{
    public class DeskDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool MacBook { get; set; }
        public bool Camera { get; set; }
        public bool Headset { get; set; }
        public RoomDto Room { get; set; }
        public DeskStatus Status { get; set; }

        public static implicit operator Desk(DeskDto desk)
        {
            return new Desk
            {
                Id = desk.Id,
                Title = desk.Title,
                MacBook = desk.MacBook,
                Camera = desk.Camera,
                Headset = desk.Headset,
                Room = desk.Room,
                Status = desk.Status
            };
        }

        public static implicit operator DeskDto(Desk desk)
        {
            return new DeskDto
            {
                Id = desk.Id,
                Title = desk.Title,
                MacBook = desk.MacBook,
                Camera = desk.Camera,
                Headset = desk.Headset,
                Room = desk.Room,
                Status = desk.Status
            };
        }

    }
}
