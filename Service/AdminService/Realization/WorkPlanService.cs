using System;
using System.Linq;
using DB.Entity;
using Repository.Interface;
using Repository.UnitOfWork;
using Service.AdminService.DTO;
using Service.AdminService.Interfaces;
using Service.AdminService.Mappers;
using Service.Base;

namespace Service.AdminService.Realization
{
    public class WorkPlanService:BaseService, IWorkPlansService
    {
        protected readonly IRepository<WorkPlan> Repository;
        public WorkPlanService(IUnitOfWork unitOfWork, IRepository<WorkPlan> repository)
            : base(unitOfWork)
        {
            Repository = repository;
        }

        protected IQueryable<WorkPlanDto> CreateDto(IQueryable<WorkPlan> workPlans, DateTime date)
        {
            var mapper = new WorkPlanToWorkPlanDtoDboMapper(date);
            return mapper.Map(Repository.ReadAll());
        }
        public IQueryable<WorkPlanDto> ReadAll()
        {
            return CreateDto(Repository.ReadAll(), DateTime.Today);
        }

        public IQueryable<WorkPlanDto> Update(WorkPlanDto workPlanDto)
        {
            Repository.Update((WorkPlan)workPlanDto);
            _unitOfWork.Save();
            return CreateDto(Repository.ReadAll(), DateTime.Today);
        }

        public IQueryable<WorkPlanDto> Delete(WorkPlanDto workPlanDto)
        {
            Repository.Delete((WorkPlan)workPlanDto);
            _unitOfWork.Save();
            return CreateDto(Repository.ReadAll(), DateTime.Today);
        }
    }
}