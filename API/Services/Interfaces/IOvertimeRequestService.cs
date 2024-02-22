using API.Models;

namespace API.Services.Interfaces
{
    public interface IOvertimeRequestService
    {
        Task<IEnumerable<OvertimeRequest>?> GetAllAsync();
        Task<OvertimeRequest?> GetByIdAsync(Guid id);
        Task<int> CreateAsync(OvertimeRequest employee);
        Task<int> UpdateAsync(Guid id, OvertimeRequest employee);
        Task<int> DeleteAsync(Guid id);
    }
}
