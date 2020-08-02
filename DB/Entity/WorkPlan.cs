using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DB.Entity
{

    [Table("WorkPlans")]
    public class WorkPlan
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("work-plan_id")]
        public int Id { get; set; }

        [Required]
        [Column("work-plan_type")]
        public string Plan { get; set; }

        [Required]
        [Column("description")]
        public string PlanDescription { get; set; }

        [Column("min_days_per_month")]
        public byte MinOfficeDay { get; set; }

        [Column("max_days_per_month")]
        public byte MaxOfficeDay { get; set; }

        [Column("priority")]
        public short? Priority { get; set; }

        [Column("guaranteed_desk")]
        public bool DeskGuaranteed { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
