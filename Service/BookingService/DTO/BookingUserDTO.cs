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

        public static implicit operator BookingUserDTO(User user)
        {
            return new BookingUserDTO
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName

            };
        }
    }
}
