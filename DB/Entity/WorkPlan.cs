using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DB.Entity
{

    [Table("WorkPlans")]
    public class WorkPlan
    {
        [Key]
        [Column("workplan_id")]
        public int ID { get; set; }

        [Required]
        [Column("workplan_type")]
        public string Plan { get; set; }

        [Required]
        [Column("description")]
        public string PlanDescription { get; set; }

        [Column("min_days_per_month")]
        public short MinOfficeDay { get; set; }

        [Column("min_days_per_month")]
        public short MaxOfficeDay { get; set; }

        [Column("priority")]
        public short Priority { get; set; }

        [Column("guaranteed_desk")]
        public bool DeskGuaranteed { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
