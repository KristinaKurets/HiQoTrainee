﻿using System;
using DB.Entity;
using DB.EntityStatus;
using DtoCommon.DTO.EntitiesStatuses;

namespace DtoCommon.DTO.Entities
{
    public class UserDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public UserPositionDto Position { get; set; }
        public UserRoleDto Role { get; set; }
        public WorkPlanDto WorkPlan { get; set; }
        public RoomDto Room { get; set; }
        public DeskDto Desk { get; set; }
        public DateTime? PlanChangeDate { get; set; }

        public static implicit operator UserDto(User user)
        {
            return new UserDto()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Desk = user.Desk,
                Email = user.Email,
                PlanChangeDate = user.PlanChangeDate,
                Position = user.Position,
                Role = (UserRoleDto) user.Role,
                Room = user.Room, 
                WorkPlan = user.WorkPlan
            };
        }

        public static explicit operator User(UserDto user)
        {
            return new User()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                DeskId = user.Desk?.Id,
                Email = user.Email,
                PlanChangeDate = user.PlanChangeDate,
                UserPositionId = user.Position.Id,
                Role = (UserRole) user.Role,
                RoomId = user.Room?.Id,
                WorkPlanId = user.WorkPlan?.Id
            };
        }
    }
}