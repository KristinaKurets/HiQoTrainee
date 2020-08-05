using DB.Entity;
using Service.BookingService.DTO.Status;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.BookingService.DTO
{
    public class BookingOrderDTO
    {
     
        public long Id { get; set; }
        public BookingStatusDTO Status { get; set; }
        public BookingDeskDTO Desk { get; set; }
        public BookingUserDTO User { get; set; }
        public DateTime DateTime { get; set; }

        public static implicit operator BookingOrderDTO(Order order)
        {
            return new BookingOrderDTO()
            {
                Id = order.Id,
                Status = order.Status,
                Desk = order.Desk,
                DateTime = order.DateTime,
                User = order.User

            };
        }
    }
}
