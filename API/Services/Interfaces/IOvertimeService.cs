using API.DTOs.Overtimes;

namespace API.Services.Interfaces
{
    public interface IOvertimeService
    {
        Task<IEnumerable<OvertimeResponseDto>?> GetAllAsync();
        Task<OvertimeResponseDto?> GetByIdAsync(Guid id);
        Task<int> CreateAsync(OvertimeRequestDto entity);
        Task<int> UpdateAsync(Guid id, OvertimeRequestDto entity);
        Task<int> DeleteAsync(Guid id);
    }
}
