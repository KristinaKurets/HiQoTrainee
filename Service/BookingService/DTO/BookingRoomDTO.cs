using System;
using System.Collections.Generic;
using System.Text;

namespace Service.BookingService.DTO
{
    class BookingRoomDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public short MaxEmployees { get; set; }
        public short Floor { get; set; }
        public virtual ICollection<BookingDeskDTO> Desks { get; set; }
        public virtual BookingUserDTO Users { get; set; }
    }
}
