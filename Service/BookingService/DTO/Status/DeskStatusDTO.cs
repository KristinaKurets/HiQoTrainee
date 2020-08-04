using Common.Extension;
using DB.EntityStatus;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.BookingService.DTO.Status
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
