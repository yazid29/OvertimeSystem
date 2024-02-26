using API.DTOs.Roles;

namespace API.Services.Interfaces
{
    public interface IRoleService
    {
        Task<IEnumerable<RoleResponseDto>?> GetAllAsync();
        Task<RoleResponseDto?> GetByIdAsync(Guid id);
        Task<int> CreateAsync(RoleRequestDto employee);
        Task<int> UpdateAsync(Guid id, RoleRequestDto employee);
        Task<int> DeleteAsync(Guid id);
    }
}
