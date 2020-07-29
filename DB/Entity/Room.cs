using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DB.Entity
{
    [Table("Rooms")]
    public class Room
    {
        [Key]
        [Column("room_id")]
        public int ID { get; set; }

        [Required]
        [Column("title")]
        public string Title { get; set; }
        
        [Column("max_employees")]
        public short MaxEmployees { get; set; }
        
        [Column("floor")]
        public short Floor { get; set; }

        public virtual ICollection<Desk> Desks { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
