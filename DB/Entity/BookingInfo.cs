using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DB.Entity
{
    public class BookingInfo
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("booking-info_id")]
        public int Id { get; set; }

        [Required]
        [Column("time-open-for-booking")]
        public TimeSpan TimeOpenForBooking { get; set; }

        [Required]
        [Column("time-close-for-booking")]
        public TimeSpan TimeCloseForBooking { get; set; }

        [Required]
        [Column("days-open-for-booking")]
        public int DaysOpenForBooking { get; set; }

        [Required]
        [Column("days-close-for-booking")]
        public int DaysCloseForBooking { get; set; }

        public virtual ICollection<Room> Rooms { get; set; }
    }
}