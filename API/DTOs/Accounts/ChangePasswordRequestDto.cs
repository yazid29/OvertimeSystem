namespace API.DTOs.Accounts;

public class ChangePasswordRequestDto
{
    public string Email { get; init; }
    public int Otp { get; init; }
    public string NewPassword { get; init; }
    public string ConfirmPassword { get; init; }
}
