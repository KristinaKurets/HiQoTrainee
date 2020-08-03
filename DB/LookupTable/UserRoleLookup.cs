using DB.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DB.LookupTable
{

    [Table("Roles")]
    public class UserRoleLookup
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("roles_id")]
        public short ID { get; set; }

        [Required]
        [Column("role_type")]
        public string Role { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}

