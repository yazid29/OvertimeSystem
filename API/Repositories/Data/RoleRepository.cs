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

        public async Task<Role?> GetGuidbyRole(string role)
        {
            //return await _context.Set<Role>().Where(e => e.Name == role).FirstOrDefaultAsync();
            return await _context.Set<Role>().FirstOrDefaultAsync(e => e.Name.Contains(role));
        }
    }
}
