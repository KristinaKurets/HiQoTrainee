using System;
using System.Linq;
using AutoMapper;
using DB.Entity;
using Repository.Interface;
using Repository.UnitOfWork;
using Service.AdminService.DTO.Entities;
using Service.AdminService.Interfaces;

namespace Service.AdminService.Realization
{
    public class WorkPlanService:IWorkPlansService
    {
        protected readonly IUnitOfWork UnitOfWork;
        public WorkPlanService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        protected IQueryable<WorkPlanDto> CreateDto()
        {
            var repository = UnitOfWork.GetRepository<WorkPlan>();
            var mapper=new MapperConfiguration(cm=>cm.CreateMap<WorkPlan, WorkPlanDto>()).CreateMapper();
            return mapper.Map<IQueryable<WorkPlanDto>>(repository.ReadAll());
        }
        public IQueryable<WorkPlanDto> ReadAll()
        {
            return CreateDto();
        }

        public IQueryable<WorkPlanDto> Update(WorkPlanDto workPlanDto)
        {
            var repository = UnitOfWork.GetRepository<WorkPlan>();
            repository.Update((WorkPlan)workPlanDto);
            UnitOfWork.Save();
            return CreateDto();
        }

        public IQueryable<WorkPlanDto> Delete(WorkPlanDto workPlanDto)
        {
            var repository = UnitOfWork.GetRepository<WorkPlan>();
            repository.Delete((WorkPlan)workPlanDto);
            UnitOfWork.Save();
            return CreateDto();
        }
    }
}