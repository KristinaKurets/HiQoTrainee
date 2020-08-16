using Common.Extension;
using DB.EntityStatus;

namespace DtoCommon.BookingDTO.Status
{
    public class BookingStatusDTO
    {
        public short Id { get; set; }
        public string Description { get; set; }

        public static implicit operator BookingStatusDTO(BookingStatus status)
        {
            return new BookingStatusDTO
            {
                Id = (short)status,
                Description = status.GetDescription()

            };
        }
    }
}
