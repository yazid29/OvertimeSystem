using API.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace API.Data
{
    public class OvertimeServiceDbContext : DbContext
    {
        public OvertimeServiceDbContext(DbContextOptions<OvertimeServiceDbContext> options) : base(options) {}
        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountRole> AccountRoles { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Overtime> Overtimes { get; set; }
        public DbSet<OvertimeRequest> OvertimeRequests { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}
