using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DB.EntityStatus;

namespace DB.Entity
{
    [Table("Users")]
    public class User
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("user_id")]
        public int Id { get; set; }

        [Required]
        [Column("first_name")]
        public string FirstName { get; set; }

        [Required]
        [Column("last_name")]
        public string LastName { get; set; }

        [Required]
        [Column("user_email")]
        public string Email { get; set; }

        [Required]
        [Column("positions_id")]
        [ForeignKey("Position")]
        public int UserPositionId { get; set; }
        public virtual UserPosition Position { get; set; }

        [Required]
        [ForeignKey("role_id")]
        public UserRole Role { get; set; }

        
        [Column("work-plan_id")]
        [ForeignKey("WorkPlan")]
        public int? WorkPlanId { get; set; }
        public virtual WorkPlan WorkPlan { get; set; }

        [Column("room_id")]
        [ForeignKey("Room")]
        public int? RoomId { get; set; }
        public virtual Room Room { get; set; }

        [Column("desk_id")]
        [ForeignKey("Desk")]
        public int? DeskId { get; set; }
        public virtual Desk Desk { get; set; }

        [Column("date_of_change_plan")]
        public DateTime? PlanChangeDate { get; set; }
        public bool BookingCancellationNotification { get; set; }
        public bool BookingConfirmationNotification { get; set; }
        public bool СalendarSyncNotification { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
