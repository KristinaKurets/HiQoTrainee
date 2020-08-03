﻿using DB.Entity;

namespace Service.AdminService.DTO
{
    public class WorkPlanDto
    {
        public int Id { get; set; }
        public string Plan { get; set; }
        public string PlanDescription { get; set; }
        public byte MinOfficeDay { get; set; }
        public byte MaxOfficeDay { get; set; }
        public short? Priority { get; set; }
        public bool DeskGuaranteed { get; set; }

        public static explicit operator WorkPlan(WorkPlanDto workPlan)
        {
            return new WorkPlan()
            {
                DeskGuaranteed = workPlan.DeskGuaranteed,
                Id = workPlan.Id,
                MaxOfficeDay = workPlan.MaxOfficeDay,
                MinOfficeDay = workPlan.MinOfficeDay,
                Plan = workPlan.Plan,
                PlanDescription = workPlan.PlanDescription,
                Priority = workPlan.Priority
            };
        }
    }
}