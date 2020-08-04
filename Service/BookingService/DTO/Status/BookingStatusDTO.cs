using Common.Extension;
using DB.EntityStatus;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.BookingService.DTO.Status
{
    class BookingStatusDTO
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
