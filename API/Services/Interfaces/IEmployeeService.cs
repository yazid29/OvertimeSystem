using API.Models;

namespace API.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>?> GetAllAsync();
        Task<Employee?> GetByIdAsync(Guid id);
        Task<int> CreateAsync(Employee employee);
        Task<int> UpdateAsync(Guid id,Employee employee);
        Task<int> DeleteAsync(Guid id);
    }
}
