using System;
using System.Linq;
using AutoMapper;
using DB.Entity;
using Service.AdminService.DTO;

namespace Service.AdminService.Mappers
{
    public class WorkPlanToWorkPlanDtoDboMapper
    {
        protected readonly Mapper Mapper;
        protected readonly DateTime Time;
        public WorkPlanToWorkPlanDtoDboMapper(DateTime time)
        {
            var mapperConfig=new MapperConfiguration(mc=>mc.CreateMap<WorkPlan, WorkPlanDto>());
            Mapper=new Mapper(mapperConfig);
            Time = time;
        }

        public IQueryable<WorkPlanDto> Map(IQueryable<WorkPlan> workPlans)
        {
            return workPlans.Select(u=>Mapper.Map<WorkPlanDto>(u));
        }
    }
}