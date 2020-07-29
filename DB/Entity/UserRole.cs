using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DB.Entity
{

    [Table("Roles")]
    public class UserRole
    {
        [Key]
        [Column("roles_id")]
        public int ID { get; set; }

        [Required]
        [Column("role_type")]
        public string Role { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}

