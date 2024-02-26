namespace API.DTOs.AccountRoles
{
    public record AccountRoleRequestDto(
        Guid AccountId,
        Guid RoleId
        );
}
