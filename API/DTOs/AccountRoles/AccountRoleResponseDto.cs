using System.ComponentModel.DataAnnotations.Schema;

namespace API.DTOs.AccountRoles
{
    public record AccountRoleResponseDto(
        Guid Id,
        Guid AccountId,
        Guid RoleId
        );
}
