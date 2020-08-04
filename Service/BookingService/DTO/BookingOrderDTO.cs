using Service.BookingService.DTO.Status;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.BookingService.DTO
{
    class BookingOrderDTO
    {
     
        public long Id { get; set; }
        public BookingStatusDTO Status { get; set; }
        public BookingDeskDTO Desk { get; set; }
        public BookingUserDTO User { get; set; }
        public DateTime DateTime { get; set; }
    }
}
