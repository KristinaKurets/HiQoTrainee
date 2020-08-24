namespace DtoCommon.CreateDto
{
    public class CreateRoomDto
    {
        public string Title { get; set; }
        public short MaxEmployees { get; set; }
        public short Floor { get; set; }
        public int? BookingInfoId { get; set; }
    }
}