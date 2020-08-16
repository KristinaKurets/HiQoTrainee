using Common.Extension;
using DB.EntityStatus;

namespace DtoCommon.BookingDTO.Status
{
    public class DeskStatusDTO
    {
        public short Id { get; set; }
        public string Description { get; set; }

        public static implicit operator DeskStatusDTO(DeskStatus status)
        {
            return new DeskStatusDTO
            {
                Id = (short)status,
                Description = status.GetDescription()
                
            };
        }
    }
}
