
namespace AutoRepairManagerApp.Core.Services;
public interface IEmailService
{
    Task SendEmailAsync(string email, string subject, string message);
    string GenerateVerificationCode();
    Task VerifyEmail(Guid userId);
}
