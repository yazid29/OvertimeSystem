using API.DTOs.Employees;
using API.Models;

namespace API.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeResponseDto>?> GetAllAsync();
        Task<EmployeeResponseDto?> GetByIdAsync(Guid id);
        Task<int> CreateAsync(RegisterDto employee);
        Task<int> UpdateAsync(Guid id, RegisterDto employee);
        Task<int> DeleteAsync(Guid id);
    }
}
