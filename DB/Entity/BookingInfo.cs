using System;
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

        [Required]
        [Column("room_id")]
        [ForeignKey("Room")]
        public int RoomId { get; set; }
        public Room Room { get; set; }
    }
}