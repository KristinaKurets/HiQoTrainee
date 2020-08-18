using DB.Entity;

namespace Service.AdminService.Changers
{
    public static class WorkingDaysCalendarChanger
    {
        public static WorkingDaysCalendar ChangeFromDto(WorkingDaysCalendar workingDays, WorkingDaysCalendar source)
        {
            workingDays.IsOff = source.IsOff;
            workingDays.WorkEndTime = source.WorkEndTime;
            workingDays.WorkStartTime = source.WorkStartTime;
            return workingDays;
        }
    }
}