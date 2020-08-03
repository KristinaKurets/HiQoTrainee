using System.Linq;
using Service.AdminService.DTO.Entities;

namespace Service.AdminService.Interfaces
{
    public interface IUserSetupService
    {
        IQueryable<UserDto> ReadAll();
        IQueryable<UserDto> Create(UserDto user);
        IQueryable<UserDto> Update(UserDto user);
        IQueryable<UserDto> Delete(UserDto user);
    }
}