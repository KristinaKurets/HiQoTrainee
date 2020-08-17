using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RequestLogger.Entities
{
    [Table("BadRequestLog")]
    public class BadRequestEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID")]
        public long ID { get; set; }
        [Column("Method")]
        public string Method { get; set; }
        [Column("Exeption")]
        public string Exeption { get; set; }
        [Column("Date")]
        public DateTime Date { get; set; }
    }
}
