using System.Collections.Generic;
using System.Linq;
using Service.AdminService.DTO.Entities;
using Service.AdminService.DTO.EntitiesStatuses;
using Service.AdminService.DTO.LookUps;

namespace Service.AdminService.Interfaces
{
    public interface IUserSetupService
    {
        List<UserDto> ReadAll();
        List<UserDto> Create(UserDto user);
        List<UserDto> Update(UserDto user);
        List<UserDto> Delete(UserDto user);
        List<UserPositionDto> GetPositions();
        List<UserRoleLookUpDto> GetRoles();
        List<WorkPlanDto> GetWorkPlans();
        List<RoomDto> GetRooms();
        List<DeskDto> GetDesks(RoomDto room);
    }
}