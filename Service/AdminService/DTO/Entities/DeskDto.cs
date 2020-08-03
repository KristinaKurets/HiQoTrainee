using System.Collections.Generic;
using DB.Entity;
using DB.EntityStatus;
using Service.AdminService.DTO.EntitiesStatuses;

namespace Service.AdminService.DTO.Entities
{
    public class DeskDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool MacBook { get; set; }
        public bool Camera { get; set; }
        public bool Headset { get; set; }
        public RoomDto Room { get; set; }
        public DeskStatusDto Status { get; set; }
        public virtual ICollection<OrderDto> Orders { get; set; }
        public virtual ICollection<UserDto> Users { get; set; }

        public static implicit operator DeskDto(Desk desk)
        {
            return new DeskDto()
            {
                Id = desk.Id,
                Title = desk.Title,
                MacBook = desk.MacBook,
                Camera = desk.Camera,
                Headset = desk.Headset,
                Room = desk.Room,
                Status = (DeskStatusDto) desk.Status,
                Orders = (ICollection<OrderDto>) desk.Orders,
                Users = (ICollection<UserDto>)desk.Users
            };
        }

        public static explicit operator Desk(DeskDto desk)
        {
            return new Desk()
            {
                Id = desk.Id,
                Title = desk.Title,
                MacBook = desk.MacBook,
                Camera = desk.Camera,
                Headset = desk.Headset,
                Room = (Room) desk.Room,
                Status = (DeskStatus) desk.Status,
                Orders = (ICollection<Order>) desk.Orders,
                Users = (ICollection<User>) desk.Users
            };
        }
    }
}