using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HQRBDBModel.Entity
{
    [Table("Booking_status")]
    public class BookingStatus
    {
        [Key]
        [Column("booking_status_id")]
        public short ID { get; set; }


        [Required]
        [Column("description")]
        public string Description { get; set; }
    
        public virtual ICollection<Order> Orders { get; set; }
    }
}
