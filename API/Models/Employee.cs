using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace API.Models
{
    [Table("tb_m_employees")]
    public class Employee
    {
        [Key, Column("id", TypeName = "char(36)")]
        public Guid Id { get; set; } // Primary Key.
        [Column("nik", TypeName = "nchar(6)")]
        public string Nik { get; set; } = string.Empty;
        [Column("first_name", TypeName = "nvarchar(50)")]
        public string FirstName { get; set; } = string.Empty;
        [Column("last_name", TypeName = "nvarchar(50)")]
        public string? LastName { get; set; }
        [Column("salary")]
        public int Salary { get; set; }
        [Column("joined_date")]
        public DateTime JoinedDate { get; set; }
        [Column("email", TypeName = "nvarchar(50)")]
        public string Email { get; set; } = string.Empty;
        [Column("position", TypeName = "nvarchar(50)")]
        public string Position { get; set; } = string.Empty;
        [Column("department", TypeName = "nvarchar(50)")]
        public string Department { get; set; } = string.Empty;
        [Column("manager_id", TypeName = "char(36)")]
        public Guid? ManagerId { get; set; }
        // Cardinality
        public virtual Account? Account { get; set; }
        public virtual Employee? Manager { get; set; }
        public virtual ICollection<Employee>? Employees { get; set; }

    }
}