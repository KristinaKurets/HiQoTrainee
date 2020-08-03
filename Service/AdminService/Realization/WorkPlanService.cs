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
        protected readonly IRepository<WorkPlan> Repository;
        protected readonly IUnitOfWork UnitOfWork;
        public WorkPlanService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
            Repository = unitOfWork.GetRepository<WorkPlan>();
        }

        protected IQueryable<WorkPlanDto> CreateDto()
        {
            var mapper=new MapperConfiguration(cm=>cm.CreateMap<WorkPlan, WorkPlanDto>()).CreateMapper();
            return mapper.Map<IQueryable<WorkPlanDto>>(Repository.ReadAll());
        }
        public IQueryable<WorkPlanDto> ReadAll()
        {
            return CreateDto();
        }

        public IQueryable<WorkPlanDto> Update(WorkPlanDto workPlanDto)
        {
            Repository.Update((WorkPlan)workPlanDto);
            UnitOfWork.Save();
            return CreateDto();
        }

        public IQueryable<WorkPlanDto> Delete(WorkPlanDto workPlanDto)
        {
            Repository.Delete((WorkPlan)workPlanDto);
            UnitOfWork.Save();
            return CreateDto();
        }
    }
}