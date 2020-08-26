using System;
using DB.Entity;

namespace DtoCommon.DtoForCreating
{
    public class WorkingDaysCalendarCreatingDto
    {
        public DateTime Date { get; set; }
        public DateTime? WorkStartTime { get; set; }
        public DateTime? WorkEndTime { get; set; }
        public bool IsOff { get; set; }
        public int? RoomId { get; set; }

        public static explicit operator WorkingDaysCalendar(WorkingDaysCalendarCreatingDto source)
        {
            if (source.WorkStartTime != null && source.WorkEndTime!=null)
                return new WorkingDaysCalendar()
                    {
                        Date = source.Date,
                        WorkStartTime = source.WorkStartTime.Value.TimeOfDay,
                        WorkEndTime = source.WorkEndTime.Value.TimeOfDay,
                        IsOff = source.IsOff,
                        RoomId = source.RoomId
                    };
            return new WorkingDaysCalendar()
            {
                Date = source.Date,
                IsOff = source.IsOff,
                RoomId = source.RoomId
            };
        }
    }
}