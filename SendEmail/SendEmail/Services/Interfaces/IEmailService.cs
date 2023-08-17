using SendEmail.Helper;

namespace SendEmail.Services.Interfaces
{
    public interface IEmailService
    {
        Task SendEmailAsync(MailRequest mailRequest);
        Task SendEmailWithAttachmentAsync (MailRequest mailRequest);
    }
}
