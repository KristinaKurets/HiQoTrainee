using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DB.EntityStatus;

namespace DB.Entity
{
    [Table("Orders")]
    public class Order
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("order_id")]
        public long Id { get; set; }

        [Required]
        [ForeignKey("booking_status_id")]
        public BookingStatus Status { get; set; }

        [Required]
        [ForeignKey("desk_id")]
        public int DeskId { get; set; }
        public Desk Desk { get; set; }
        
        [Required]
        [ForeignKey("user_id")]
        public int UserId { get; set; }
        public User User { get; set; }

        [Column("date")]
        public DateTime DateTime { get; set; }
    }
}
