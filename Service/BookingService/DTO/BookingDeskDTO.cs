using DB.Entity;
using Service.BookingService.DTO.Status;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.BookingService.DTO
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

        public BookingOrderDTO Order { get; set; }
        public BookingUserDTO User { get; set; }

    }
}
