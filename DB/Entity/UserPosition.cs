using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DB.Entity
{
    [Table("Positions")]
    public class UserPosition
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("position_id")]
        public short Id { get; set; }

        [Required]
        [Column("position_type")]
        public string Type { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
