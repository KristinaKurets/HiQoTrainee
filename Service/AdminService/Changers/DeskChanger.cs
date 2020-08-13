using DB.Entity;
using DB.EntityStatus;
using Service.AdminService.DTO.Entities;

namespace Service.AdminService.Changers
{
    public static class DeskChanger
    {
        public static Desk ChangeFromDto(Desk desk, DeskDto source)
        {
            desk.Status = (DeskStatus) source.Status;
            desk.Title = source.Title;
            desk.Camera = source.Camera;
            desk.Headset = source.Headset;
            desk.MacBook = source.MacBook;
            desk.RoomId = source.Room.Id;
            return desk;
        }
    }
}