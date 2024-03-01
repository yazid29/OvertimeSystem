using API.Data;
using API.Models;
using API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories.Data
{
    public class RoleRepository : GeneralRepository<Role>, IRoleRepository
    {
        public RoleRepository(OvertimeServiceDbContext context) : base(context)
        {
        }
        public async Task<Role?> GetByNameAsync(string name)
        {
            return await _context.Set<Role>().FirstOrDefaultAsync(r => r.Name.Contains(name));
        }
        public async Task<Role?> GetGuidbyRole(string role)
        {
            //return await _context.Set<Role>().Where(e => e.Name == role).FirstOrDefaultAsync();
            return await _context.Set<Role>().FirstOrDefaultAsync(e => e.Name.Contains(role));
        }
        public async Task<IEnumerable<string>> GetAllRoleAsync(Guid id)
        {
            return await _context.Set<AccountRole>()
                .Where(x=>x.AccountId==id)
                .Select(x => x.Role.Name).ToListAsync();
        }
    }
}
