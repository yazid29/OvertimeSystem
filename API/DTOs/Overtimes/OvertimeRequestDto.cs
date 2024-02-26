﻿namespace API.DTOs.Overtimes
{
    public record OvertimeRequestDto(
        DateTime Date,
        string Reason,
        int TotalHours,
        string Status,
        string Document
        );
}
