using System;
using System.Collections.Generic;
using DB.Entity;
using DB.EntityStatus;
using DB.LookupTable;
using Service.AdminService.DTO.Entities;

namespace Service.AdminService.DTO.LookUps
{
    public class UserRoleLookUpDto
    {
        public short Id { get; set; }
        public string Role { get; set; }
        public virtual ICollection<UserDto> Users { get; set; }

        public static implicit operator UserRoleLookUpDto(UserRoleLookup role)
        {
            return new UserRoleLookUpDto()
            {
                Id = role.ID,
                Role = role.Role,
                Users = (ICollection<UserDto>) role.Users
            };
        }

        public static explicit operator UserRoleLookup(UserRoleLookUpDto role)
        {
            return new UserRoleLookup()
            {
                ID = role.Id,
                Role = role.Role,
                Users = (ICollection<User>) role.Users
            };
        }

        public static explicit operator UserRole(UserRoleLookUpDto role)
        {
            return Enum.Parse<UserRole>(role.Role, true);
        }
    }
}