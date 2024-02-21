using API.Data;
using API.Models;
using API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories.Data
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly OvertimeServiceDbContext _context;

        public EmployeeRepository(OvertimeServiceDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Employee>> GettAllAsync()
        {
            return await _context.Set<Employee>().ToListAsync();
        }
        public async Task<Employee> CreateAsync(Employee employee)
        {
            await _context.Set<Employee>().AddAsync(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task<Employee?> GetByIdAsync(Guid id)
        {
            return await _context.Set<Employee>().FindAsync(id);
        }

        public async Task UpdateAsync(Employee employee)
        {
            _context.Set<Employee>().Update(employee);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Employee employee)
        {
            _context.Set<Employee>().Remove(employee);
            await _context.SaveChangesAsync();
        }
    }
}
