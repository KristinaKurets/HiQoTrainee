using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DB.Entity
{
    [Table("Desks_status")]
    public class DeskStatus
    {
        [Key]
        [Column("desks_status_id")]
        public int ID { get; set; }

        [Required]
        [Column("status")]
        public string Status { get; set; }

        public virtual ICollection<Desk> Desks { get; set; }
    }
}
