using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs.OvertimeRequests
{
    public record OvertimeReqRequestDto(
        Guid AccountId,
        Guid OvertimeId,
        string Status,
        string? Comment
        );
}
