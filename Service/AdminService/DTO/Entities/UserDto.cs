using System;
using System.Collections.Generic;
using DB.Entity;
using DB.EntityStatus;
using Service.AdminService.DTO.EntitiesStatuses;

namespace Service.AdminService.DTO.Entities
{
    public class UserDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int UserPositionId { get; set; }
        public UserRoleDto Role { get; set; }
        public int? WorkPlanId { get; set; }
        public int? RoomId { get; set; }
        public int? DeskId { get; set; }
        public DateTime? PlanChangeDate { get; set; }

        public static implicit operator UserDto(User user)
        {
            return new UserDto()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                DeskId = user.DeskId,
                Email = user.Email,
                PlanChangeDate = user.PlanChangeDate,
                UserPositionId = user.UserPositionId,
                Role = (UserRoleDto) user.Role,
                RoomId = user.RoomId, 
                WorkPlanId = user.WorkPlanId
            };
        }

        public static explicit operator User(UserDto user)
        {
            return new User()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                DeskId = user.DeskId,
                Email = user.Email,
                PlanChangeDate = user.PlanChangeDate,
                UserPositionId = user.UserPositionId,
                Role = (UserRole) user.Role,
                RoomId = user.RoomId,
                WorkPlanId = user.WorkPlanId
            };
        }
    }
}