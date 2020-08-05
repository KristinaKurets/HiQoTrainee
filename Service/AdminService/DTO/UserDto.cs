using DB.Entity;
using DB.EntityStatus;
using System;

namespace Service.AdminService.DTO
{
    public class UserDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public UserPositionDto Position { get; set; }
        public UserRole Role { get; set; }
        public WorkPlanDto WorkPlan { get; set; }
        public RoomDto Room { get; set; }
        public DeskDto Desk { get; set; }

        //public static implicit operator User(UserDto user)
        //{
        //    return new User
        //    {
        //        Id = user.Id,
        //        FirstName = user.FirstName,
        //        LastName = user.LastName,
        //        Role = user.Role,
        //        WorkPlan = user.WorkPlan,
        //        Room = user.Room,
        //        Desk = user.Desk
        //    };
        //}

        //public static implicit operator UserDto(User user)
        //{
        //    return new UserDto
        //    {
        //        Id = user.Id,
        //        FirstName = user.FirstName,
        //        LastName = user.LastName,
        //        Role = user.Role,
        //        WorkPlan = user.WorkPlan,
        //        Room = user.Room,
        //        Desk = user.Desk
        //    };
        //}
    }
}
