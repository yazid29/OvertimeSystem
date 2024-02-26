namespace API.DTOs.OvertimeRequests
{
    public record OvertimeReqResponseDto(
        Guid Id,
        Guid AccountId,
        Guid OvertimeId,
        DateTime Timestamp,
        string Status,
        string? Comment
        );
}
