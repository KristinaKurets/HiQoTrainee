using System.Linq;
using Service.AdminService.DTO.Entities;
using Service.AdminService.DTO.EntitiesStatuses;
using Service.AdminService.DTO.LookUps;

namespace Service.AdminService.Interfaces
{
    public interface IUserSetupService
    {
        IQueryable<UserDto> ReadAll();
        IQueryable<UserDto> Create(UserDto user);
        IQueryable<UserDto> Update(UserDto user);
        IQueryable<UserDto> Delete(UserDto user);
        IQueryable<UserPositionDto> GetPositions();
        IQueryable<UserRoleLookUpDto> GetRoles();
        IQueryable<WorkPlanDto> GetWorkPlans();
        IQueryable<RoomDto> GetRooms();
        IQueryable<DeskDto> GetDesks(RoomDto room);
    }
}