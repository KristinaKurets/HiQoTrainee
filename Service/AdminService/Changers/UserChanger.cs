using DB.Entity;
using DB.EntityStatus;
using Service.AdminService.DTO.Entities;

namespace Service.AdminService.Changers
{
    public static class UserChanger
    {
        public static User ChangeFromDto(User user, UserDto source)
        {
            user.Email = source.Email;
            user.FirstName = source.FirstName;
            user.LastName = source.LastName;
            user.PlanChangeDate = source.PlanChangeDate;
            user.Role = (UserRole) source.Role;
            return user;
        }
    }
}