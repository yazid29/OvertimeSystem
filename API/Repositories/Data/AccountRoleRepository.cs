using API.Data;
using API.Models;
using API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories.Data
{
    public class AccountRoleRepository : GeneralRepository<AccountRole>, IAccountRoleRepository
    {
        public AccountRoleRepository(OvertimeServiceDbContext context) : base(context)
        {

        }
        public async Task<AccountRole?> GetDataByAccountIdAndRoleAsync(Guid accountId, Guid roleId)
        {
            var getByAccountId = await GetByAccountIdAsync(accountId);
            var data = getByAccountId.FirstOrDefault(ar => ar.RoleId == roleId);
            return data;
        }

        public async Task<IEnumerable<AccountRole?>> GetByAccountIdAsync(Guid accountId)
        {
            var data = _context.Set<AccountRole>().Where(ar => ar.AccountId == accountId);
            return data;
        }
    }
}
