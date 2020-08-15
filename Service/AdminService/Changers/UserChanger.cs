using DB.Entity;
using DB.EntityStatus;

namespace Service.AdminService.Changers
{
    public static class UserChanger
    {
        public static User ChangeFromDto(User user, User source)
        {
            user.Email = source.Email;
            user.FirstName = source.FirstName;
            user.LastName = source.LastName;
            user.PlanChangeDate = source.PlanChangeDate;
            user.Role = (UserRole) source.Role;
            user.RoomId = source.Room.Id;
            user.WorkPlanId = source.WorkPlan.Id;
            user.DeskId = source.Desk.Id;
            user.UserPositionId = source.Position.Id;
            return user;
        }
    }
}