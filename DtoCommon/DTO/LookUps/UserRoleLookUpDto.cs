﻿using System;
using DB.EntityStatus;
using DB.LookupTable;

namespace DtoCommon.DTO.LookUps
{
    public class UserRoleLookUpDto
    {
        public short Id { get; set; }
        public string Role { get; set; }

        public static implicit operator UserRoleLookUpDto(UserRoleLookup role)
        {
            return new UserRoleLookUpDto()
            {
                Id = role.ID,
                Role = role.Role
            };
        }

        public static explicit operator UserRoleLookup(UserRoleLookUpDto role)
        {
            return new UserRoleLookup()
            {
                ID = role.Id,
                Role = role.Role
            };
        }

        public static explicit operator UserRole(UserRoleLookUpDto role)
        {
            return Enum.Parse<UserRole>(role.Role, true);
        }
    }
}