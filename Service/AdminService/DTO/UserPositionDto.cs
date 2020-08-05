using DB.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.AdminService.DTO
{
    public class UserPositionDto
    {
        public short Id { get; set; }
        public string Type { get; set; }

        public static implicit operator UserPosition(UserPositionDto position)
        {
            return new UserPosition
            {
                Id = position.Id,
                Type = position.Type
            };
        }

        public static implicit operator UserPositionDto(UserPosition position)
        {
            return new UserPositionDto
            {
                Id = position.Id,
                Type = position.Type
            };
        }
    }
}
