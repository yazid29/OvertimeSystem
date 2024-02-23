using API.DTOs.Employees;
using API.Models;

namespace API.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeResponseDto>?> GetAllAsync();
        Task<EmployeeResponseDto?> GetByIdAsync(Guid id);
        Task<int> CreateAsync(EmployeeRequestDto employee);
        Task<int> UpdateAsync(Guid id, EmployeeRequestDto employee);
        Task<int> DeleteAsync(Guid id);
    }
}
