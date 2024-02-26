using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs.OvertimeRequests
{
    public record OvertimeReqRequestDto(
        Guid AccountId,
        Guid OvertimeId,
        DateTime Timestamp,
        string Status,
        string? Comment
        );
}
