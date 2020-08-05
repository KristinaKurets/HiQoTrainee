using DB.Entity;

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

        public static implicit operator WorkPlan(WorkPlanDto plan)
        {
            return new WorkPlan
            {
                Id = plan.Id,
                Plan = plan.Plan,
                PlanDescription = plan.PlanDescription,
                MinOfficeDay = plan.MinOfficeDay,
                MaxOfficeDay = plan.MaxOfficeDay,
                Priority = plan.Priority,
                DeskGuaranteed = plan.DeskGuaranteed
            };
        }

        public static implicit operator WorkPlanDto(WorkPlan plan)
        {
            return new WorkPlanDto
            {
                Id = plan.Id,
                Plan = plan.Plan,
                PlanDescription = plan.PlanDescription,
                MinOfficeDay = plan.MinOfficeDay,
                MaxOfficeDay = plan.MaxOfficeDay,
                Priority = plan.Priority,
                DeskGuaranteed = plan.DeskGuaranteed
            };
        }
    }
}
