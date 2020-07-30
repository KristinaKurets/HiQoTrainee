using DB.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DB.LookupTable
{
    [Table("Desks_status")]
    public class DeskStatusLoockup
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("desks_status_id")]
        public int ID { get; set; }

        [Required]
        [Column("status")]
        public string Status { get; set; }

        public virtual ICollection<Desk> Desks { get; set; }
    }
}
