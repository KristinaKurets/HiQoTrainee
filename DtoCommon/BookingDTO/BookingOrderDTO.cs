using DtoCommon.BookingDTO.Status;
using System;


namespace DtoCommon.BookingDTO
{
    public class BookingOrderDTO
    {
     
        public long Id { get; set; }
        public BookingStatusDTO Status { get; set; }
        public BookingDeskDTO Desk { get; set; }
        public BookingUserDTO User { get; set; }
        public DateTime DateTime { get; set; }

    }
}
