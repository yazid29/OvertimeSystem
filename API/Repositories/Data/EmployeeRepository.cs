using API.Data;
using API.Models;
using API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories.Data
{
    public class EmployeeRepository : GeneralRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(OvertimeServiceDbContext context) : base(context)
        {
        }

        public async Task<Employee?> GetByEmailAsync(string email)
        {
            return await _context.Set<Employee>().Where(emp => emp.Email == email).FirstOrDefaultAsync();
        }

        public async Task<Employee?> GetByNikAsync(string nik)
        {
            return await _context.Set<Employee>().Where(e => e.Nik == nik).FirstOrDefaultAsync();
        }
        public async Task<string?> GetLastNikAsync()
        {
            return _context.Set<Employee>().ToList().Select(e => e.Nik).LastOrDefault();
        }
    }
}
