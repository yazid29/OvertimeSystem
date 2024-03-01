using API.DTOs.Accounts;

namespace API.Services.Interfaces
{
    public interface IEmailHandler
    {
        Task SendEmailAsync(EmailDto emailDto);
    }
}
