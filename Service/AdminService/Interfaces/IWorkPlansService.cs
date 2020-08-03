using System.Linq;
using Service.AdminService.DTO;

namespace Service.AdminService.Interfaces
{
    public interface IWorkPlansService
    {
        IQueryable<WorkPlanDto> ReadAll();
        IQueryable<WorkPlanDto> Update(WorkPlanDto workPlanDto);
        IQueryable<WorkPlanDto> Delete(WorkPlanDto workPlanDto);
    }
}