using API.Contracts;
using API.Models;

namespace API.Repositories.Interfaces
{
    public interface IRoleRepository : IGeneralRepository<Role>
    {
        Task<Role?> GetGuidbyRole(string role);
    }
}
