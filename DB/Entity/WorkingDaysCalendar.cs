using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DB.Entity
{
    [Table("Calendar")]
    public class WorkingDaysCalendar
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("day_id")]
        public long Id { get; set; }
        
        [Column("date")]
        public DateTime Date { get; set; }

        [Column("start_of_work", TypeName = "time")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{HH:mm:ss}")]
        public TimeSpan? WorkStartTime { get; set; }


        [Column("end_of_work", TypeName = "time")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{HH:mm:ss}")]
        public TimeSpan? WorkEndTime { get; set; }

        [Column("is_dayoff")]
        public bool IsOff { get; set; }


        [Column("room_id")]
        [ForeignKey("Room")]
        public int? RoomId { get; set; }
        public Room Room { get; set; }
    }
}
