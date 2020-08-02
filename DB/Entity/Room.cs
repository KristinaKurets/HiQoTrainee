using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DB.Entity
{
    [Table("Rooms")]
    public class Room
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("room_id")]
        public int Id { get; set; }

        [Required]
        [Column("title")]
        public string Title { get; set; }
        
        [Column("max_employees")]
        public short MaxEmployees { get; set; }
        
        [Column("floor")]
        public short Floor { get; set; }

        public virtual ICollection<Desk> Desks { get; set; }
        public virtual ICollection<User> Users { get; set; }
    
        public virtual ICollection<WorkingDaysCalendar> BookingCalendars { get; set; }
    }
}
