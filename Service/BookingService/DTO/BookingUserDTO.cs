using DB.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.BookingService.DTO
{
    public class BookingUserDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
