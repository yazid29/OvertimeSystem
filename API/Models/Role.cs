using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    [Table("tb_m_roles")]
    public class Role
    {
        [Key, Column("id", TypeName = "char(36)")]
        public Guid Id { get; set; }
        [Column("name", TypeName = "nvarchar(25)")]
        public string Name { get; set; } = string.Empty;

        // Cardinality
        public ICollection<AccountRole>? AccoutRoles { get; set; }
    }
}