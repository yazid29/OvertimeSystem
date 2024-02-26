using API.DTOs.OvertimeRequests;

namespace API.Services.Interfaces
{
    public interface IOvertimeRequestService
    {
        Task<IEnumerable<OvertimeReqResponseDto>?> GetAllAsync();
        Task<OvertimeReqResponseDto?> GetByIdAsync(Guid id);
        Task<int> CreateAsync(OvertimeReqRequestDto employee);
        Task<int> UpdateAsync(Guid id, OvertimeReqRequestDto employee);
        Task<int> DeleteAsync(Guid id);
    }
}
