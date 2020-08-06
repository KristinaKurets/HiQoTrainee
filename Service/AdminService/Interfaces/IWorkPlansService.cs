using System.Collections.Generic;
using System.Linq;
using Service.AdminService.DTO;
using Service.AdminService.DTO.Entities;

namespace Service.AdminService.Interfaces
{
    public interface IWorkPlansService
    {
        List<WorkPlanDto> ReadAll();
        List<WorkPlanDto> Update(WorkPlanDto workPlanDto);
        List<WorkPlanDto> Delete(WorkPlanDto workPlanDto);
    }
}