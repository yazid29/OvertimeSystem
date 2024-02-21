using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    [Table("tb_m_overtimes")]
    public class Overtime
    {
        [Key, Column("id", TypeName = "char(36)")]
        public Guid Id { get; set; } // Primary Key.
        [Column("date")]
        public DateTime Date { get; set; }
        [Column("reason", TypeName = "nvarchar(255)")]
        public string Reason { get; set; } = string.Empty;
        [Column("total_hours")]
        public int TotalHours { get; set; }
        [Column("status", TypeName = "nvarchar(20)")]
        public string Status { get; set; } = string.Empty;
        [Column("document", TypeName = "nvarchar(255)")]
        public string Document { get; set; } = string.Empty;
    }
}
