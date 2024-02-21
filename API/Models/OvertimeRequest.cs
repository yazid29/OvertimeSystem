using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    [Table("tb_tr_overtime_requests")]
    public class OvertimeRequest
    {
        [Key, Column("id", TypeName = "char(36)")]
        public Guid Id { get; set; } // Primary Key.
        [Column("account_id", TypeName = "char(36)")]
        public Guid AccountId { get; set; }
        [Column("overtime_id", TypeName = "char(36)")]
        public Guid OvertimeId { get; set; }
        [Column("timestamp")]
        public DateTime Timestamp { get; set; }
        [Column("status", TypeName = "nvarchar(20)")]
        public string Status { get; set; } = string.Empty;
        [Column("comment", TypeName = "nvarchar(255)")]
        public string? Comment { get; set; }
    }
}
