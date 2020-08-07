using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DB.EntityStatus;

namespace DB.Entity
{

    [Table("Desks")]
    public class Desk
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("desk_id")]
        public int Id { get; set; }

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
        [Column("room_id")]
        [ForeignKey("Room")]
        public int RoomId { get; set; }
        public virtual Room Room { get; set; }
        
        [Required]
        [ForeignKey("status_id")]
        public DeskStatus Status { get; set; }
        public User User { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
