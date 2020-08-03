using System.Collections.Generic;
using DB.Entity;

namespace Service.AdminService.DTO.Entities
{
    public class UserPositionDto
    {
        public short Id { get; set; }
        public string Type { get; set; }

        public virtual ICollection<UserDto> Users { get; set; }

        public static implicit operator UserPositionDto(UserPosition userPosition)
        {
            return new UserPositionDto()
            {
                Id = userPosition.Id,
                Type = userPosition.Type,
                Users = (ICollection<UserDto>) userPosition.Users
            };
        }

        public static explicit operator UserPosition(UserPositionDto userPosition)
        {
            return new UserPosition()
            {
                Id = userPosition.Id,
                Type = userPosition.Type,
                Users = (ICollection<User>) userPosition.Users
            };
        }
    }
}