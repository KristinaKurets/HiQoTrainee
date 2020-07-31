using DB.EnttityStatus;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DB.Entity
{
    [Table("Orders")]
    public class Order
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("order_id")]
        public long ID { get; set; }

        [Required]
        [ForeignKey("booking_status_id")]
        public BookingStatus Status { get; set; }

        [Required]
        [ForeignKey("desk_id")]
        public Desk Desk { get; set; }
        
        [Required]
        [ForeignKey("user_id")]
        public User User { get; set; }

        [Column("date")]
        public DateTime DateTime { get; set; }
    }
}
