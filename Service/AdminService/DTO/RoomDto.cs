using DB.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.AdminService.DTO
{
    public class RoomDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public short MaxEmployees { get; set; }
        public short Floor { get; set; }

        public static implicit operator Room(RoomDto room)
        {
            return new Room
            {
                Id = room.Id,
                Title = room.Title,
                MaxEmployees = room.MaxEmployees,
                Floor = room.Floor
            };
        }

        public static implicit operator RoomDto(Room room)
        {
            return new RoomDto
            {
                Id = room.Id,
                Title = room.Title,
                MaxEmployees = room.MaxEmployees,
                Floor = room.Floor
            };
        }
    }
}
