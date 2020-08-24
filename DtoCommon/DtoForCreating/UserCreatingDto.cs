using System;
using DB.Entity;
using DB.EntityStatus;
using DtoCommon.DTO.EntitiesStatuses;

namespace DtoCommon.DtoForCreating
{
    public class UserCreatingDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int UserPositionId { get; set; }
        public UserRoleDto Role { get; set; }
        public int? WorkPlanId { get; set; }
        public int? RoomId { get; set; }
        public int? DeskId { get; set; }
        public DateTime? PlanChangeDate { get; set; }

        public static explicit operator User(UserCreatingDto user)
        {
            return new User()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                UserPositionId = user.UserPositionId,
                Role = (UserRole) user.Role,
                WorkPlanId = user.WorkPlanId,
                RoomId = user.RoomId,
                DeskId = user.DeskId,
                PlanChangeDate = user.PlanChangeDate
            };
        }
    }
}