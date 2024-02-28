using API.Contracts;
using API.Models;

namespace API.Repositories.Interfaces
{
    public interface IEmployeeRepository : IGeneralRepository<Employee>
    {
        Task<Employee?> GetByNikAsync(string nik);
        Task<Employee?> GetByEmailAsync(string email);
    }
}
