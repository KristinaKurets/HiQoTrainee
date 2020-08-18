using DB.Entity;
using DB.EntityStatus;

namespace Service.AdminService.Changers
{
    public static class DeskChanger
    {
        public static Desk ChangeFromDto(Desk desk, Desk source)
        {
            desk.Status = (DeskStatus) source.Status;
            desk.Title = source.Title;
            desk.Camera = source.Camera;
            desk.Headset = source.Headset;
            desk.MacBook = source.MacBook;
            desk.RoomId = source.RoomId;
            return desk;
        }
    }
}