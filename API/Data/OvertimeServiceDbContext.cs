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
        protected override void OnModelCreating(ModelBuilder modelBuilder) { 
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Account>()
                .HasMany(acc => acc.AccoutRoles)
                .WithOne(ar => ar.Account)
                .HasForeignKey(ar => ar.AccountId);
            modelBuilder.Entity<Account>()
                .HasMany(or => or.OvertimeRequests)
                .WithOne(ac => ac.Account) 
                .HasForeignKey(ac => ac.AccountId);
            modelBuilder.Entity<Account>()
                .HasOne(a => a.Employee)
                .WithOne(e => e.Account)
                .HasForeignKey<Account>(a => a.Id);
            modelBuilder.Entity<Role>()
                .HasMany(accRole => accRole.AccoutRoles)
                .WithOne(role => role.Role)
                .HasForeignKey(accRole => accRole.RoleId);
            modelBuilder.Entity<Employee>()
                .HasOne(manager => manager.Manager)
                .WithMany(emp => emp.Employees)
                .HasForeignKey(emp => emp.ManagerId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Overtime>()
                .HasMany(oReq => oReq.OvertimeRequest)
                .WithOne(ov => ov.Overtime)
                .HasForeignKey(oReq => oReq.OvertimeId);

        }
    }
}
