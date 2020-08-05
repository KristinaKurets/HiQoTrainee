using System.Collections.Generic;
using DB.Entity;

namespace Service.AdminService.DTO.Entities
{
    public class UserPositionDto
    {
        public short Id { get; set; }
        public string Type { get; set; }

        public static implicit operator UserPositionDto(UserPosition userPosition)
        {
            return new UserPositionDto()
            {
                Id = userPosition.Id,
                Type = userPosition.Type
            };
        }

        public static explicit operator UserPosition(UserPositionDto userPosition)
        {
            return new UserPosition()
            {
                Type = userPosition.Type
            };
        }
    }
}