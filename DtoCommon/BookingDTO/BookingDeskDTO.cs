using DtoCommon.BookingDTO.Status;


namespace DtoCommon.BookingDTO
{
    public class BookingDeskDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool MacBook { get; set; }
        public bool Camera { get; set; }
        public bool Headset { get; set; }
        public BookingRoomDTO Room { get; set; }
        public DeskStatusDTO Status { get; set; }
        public BookingUserDTO User { get; set; }

    }
}
