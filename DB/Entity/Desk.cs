using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HQRBDBModel.Entity
{

    [Table("Desks")]
    public class Desk
    {
        [Key]
        [Column("desk_id")]
        public int ID { get; set; }

        [Required]
        [Column("title")]
        public string Title { get; set; }
        
        [Column("macBook")]
        public bool MacBook { get; set; }

        [Column("camera")]
        public bool Camera { get; set; }

        [Column("headset")]
        public bool Headset { get; set; }
        
        [Required]
        [ForeignKey("room_id")]
        public Room Room { get; set; }
        
        [Required]
        [ForeignKey("status_id")]
        public DeskStatus Status { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<User> Users { get; set; }
        
    }
}
