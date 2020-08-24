using DB.Entity;
using DB.EntityStatus;
using DtoCommon.DTO.EntitiesStatuses;

namespace DtoCommon.DtoForCreating
{
    public class DeskCreatingDto
    {
        public string Title { get; set; }
        public bool MacBook { get; set; }
        public bool Camera { get; set; }
        public bool Headset { get; set; }
        public int RoomId { get; set; }
        public DeskStatusDto Status { get; set; }

        public static explicit operator Desk(DeskCreatingDto desk)
        {
            return new Desk()
            {
                Title = desk.Title,
                MacBook = desk.MacBook,
                Camera = desk.Camera,
                Headset = desk.Headset,
                RoomId = desk.RoomId,
                Status = (DeskStatus) desk.Status
            };
        }
    }
}