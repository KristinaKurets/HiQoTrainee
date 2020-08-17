using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace RequestLogger.Entities
{
    [Table("RequestProcessingLog")]
    public class RequestProcessingEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID")]
        public long ID { get; set; }
        [Column("HTTPMethod")]
        public string Method { get; set; }
        [Column("Path")]
        public string Path { get; set; }
        [Column("StatusCode")]
        public int StatusCode { get; set; }
        [Column("Date")]
        public DateTime Time { get; set; }

    }
}
