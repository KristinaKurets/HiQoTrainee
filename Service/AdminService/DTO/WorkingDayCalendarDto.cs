using DB.Entity;
using System;

namespace Service.AdminService.DTO
{
    public class WorkingDayCalendarDto
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan? WorkStartTime { get; set; }
        public TimeSpan? WorkEndTime { get; set; }
        public bool IsOff { get; set; }
        public RoomDto Room { get; set; }

        public static implicit operator WorkingDaysCalendar(WorkingDayCalendarDto calendar)
        {
            return new WorkingDaysCalendar
            {
                Id = calendar.Id,
                Date = calendar.Date,
                WorkStartTime = calendar.WorkStartTime,
                WorkEndTime = calendar.WorkEndTime,
                IsOff = calendar.IsOff,
                Room = calendar.Room
            };
        }

        public static implicit operator WorkingDayCalendarDto(WorkingDaysCalendar calendar)
        {
            return new WorkingDayCalendarDto
            {
                Id = calendar.Id,
                Date = calendar.Date,
                WorkStartTime = calendar.WorkStartTime,
                WorkEndTime = calendar.WorkEndTime,
                IsOff = calendar.IsOff,
                Room = calendar.Room
            };
        }
    }
}
