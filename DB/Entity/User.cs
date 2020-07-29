using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DB.Entity
{
    [Table("Users")]
    public class User
    {
        [Key]
        [Column("user_id")]
        public int ID { get; set; }

        [Required]
        [Column("first_name")]
        public string FirstName { get; set; }

        [Required]
        [Column("last_name")] 
        public string LastName { get; set; }

        [Required]
        [ForeignKey("positions_id")]
        public UserPosition Position { get; set; }

        [Required]
        [ForeignKey("role_id")]
        public UserRole Role { get; set; }

        
        [ForeignKey("workplan_id")]
        public WorkPlan WorkPlan { get; set; }

        [ForeignKey("room_id")]
        public Room Room { get; set; }

        [ForeignKey("desk_id")]
        public Desk Desk { get; set; }


        public virtual ICollection<Order> Orders { get; set; }
    }
}
