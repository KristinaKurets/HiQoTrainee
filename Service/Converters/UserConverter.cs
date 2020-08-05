using AutoMapper;
using DB.Entity;
using Service.AdminService.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Converters
{
    public class UserConverter : ITypeConverter<User, UserDto>
    {

        public UserDto Convert(User source, UserDto destination, ResolutionContext context)
        {
            return new UserDto
            {
                Id = source.Id,
                FirstName = source.FirstName,
                LastName = source.LastName,
                Role = source.Role,
                WorkPlan = source.WorkPlan,
                Room = source.Room,
                Desk = source.Desk
            };
        }
    }
}
