using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DB.Entity
{
    [Table("Positions")]
    public class UserPosition
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("position_id")]
        public int ID { get; set; }

        [Required]
        [Column("position_type")]
        public string Type { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
