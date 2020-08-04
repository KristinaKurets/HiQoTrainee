using System.Collections.Generic;
using System.Linq;
using Service.AdminService.DTO.Entities;
using Service.AdminService.DTO.LookUps;

namespace Service.AdminService.Interfaces
{
    public interface IAllDesksService
    {
        List<DeskDto> ReadAll();
        List<DeskDto> UpdateDesks(DeskDto desk);
        List<DeskDto> CreateDesk(DeskDto desk);
        List<DeskDto> DeleteDesk(DeskDto desk);
        List<DeskStatusLookUpDto> GetDesksStatuses();
    }
}