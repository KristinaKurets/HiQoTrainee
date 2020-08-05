using DB.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.BookingService.DTO
{
    public class BookingRoomDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public short MaxEmployees { get; set; }
        public short Floor { get; set; }
        public virtual ICollection<BookingDeskDTO> Desks { get; set; }
        public virtual ICollection<BookingUserDTO> Users { get; set; }

        public static implicit operator BookingRoomDTO(Room room)
        {
            return new BookingRoomDTO()
            {
                Id = room.Id,
                Title=room.Title,
                MaxEmployees=room.MaxEmployees,
                Floor=room.Floor,
                Desks = (ICollection<BookingDeskDTO>)room.Desks,
                Users = (ICollection<BookingUserDTO>)room.Users

            };
        }
    }
}
