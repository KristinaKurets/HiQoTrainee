using System;
using DB.Entity;

namespace Service.AdminService.DTO.Entities
{
    public class WorkingDaysCalendarDto
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan? WorkStartTime { get; set; }
        public TimeSpan? WorkEndTime { get; set; }
        public bool IsOff { get; set; }
        public int? RoomId { get; set; }

        public static implicit operator WorkingDaysCalendarDto(WorkingDaysCalendar calendar)
        {
            return new WorkingDaysCalendarDto()
            {
                Id = calendar.Id,
                Date = calendar.Date,
                WorkStartTime = calendar.WorkStartTime,
                WorkEndTime = calendar.WorkEndTime,
                IsOff = calendar.IsOff,
                RoomId = calendar.RoomId
            };
        }

        public static explicit operator WorkingDaysCalendar(WorkingDaysCalendarDto calendar)
        {
            return new WorkingDaysCalendar()
            {
                Date = calendar.Date,
                WorkStartTime = calendar.WorkStartTime,
                WorkEndTime = calendar.WorkEndTime,
                IsOff = calendar.IsOff,
                RoomId = calendar.RoomId
            };
        }
    }
}