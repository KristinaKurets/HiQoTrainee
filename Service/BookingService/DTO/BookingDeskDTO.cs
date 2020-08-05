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


        public static implicit operator BookingDeskDTO(Desk desk)
        {
            return new BookingDeskDTO
            {
                Id = desk.Id,
                Title = desk.Title,
                MacBook = desk.MacBook,
                Camera = desk.Camera,
                Headset = desk.Headset,
                Room = (BookingRoomDTO)desk.Room,
                Status = (DeskStatusDTO)desk.Status,
                Order = null,
                // это правильно, но сломается так-как в бд сущность неправильна
                User = (BookingUserDTO)desk.Users
               

            };
        }
    }
}
