using System.Collections.Generic;
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
        protected readonly IRepository<WorkPlan> Repository;
        public WorkPlanService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
            Repository = UnitOfWork.GetRepository<WorkPlan>();
        }

        protected List<WorkPlanDto> CreateDto()
        {
            var mapper=new MapperConfiguration(cm=>cm.CreateMap<WorkPlan, WorkPlanDto>()).CreateMapper();
            return mapper.Map<List<WorkPlanDto>>(Repository.ReadAll());
        }
        public List<WorkPlanDto> ReadAll()
        {
            return CreateDto();
        }

        public List<WorkPlanDto> Update(WorkPlanDto workPlanDto)
        {
            Repository.Update(Repository.Read(workPlanDto.Id));
            UnitOfWork.Save();
            return CreateDto();
        }

        public List<WorkPlanDto> Delete(WorkPlanDto workPlanDto)
        {
            Repository.Delete(Repository.Read(workPlanDto.Id));
            UnitOfWork.Save();
            return CreateDto();
        }
    }
}