using Microsoft.AspNetCore.Mvc;
using SendEmail.Helper;
using SendEmail.Services.Interfaces;

namespace SendEmail.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendEmailController : ControllerBase
    {
        private readonly IEmailService _emailService;

        public SendEmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }
        [HttpPost("{toEmail}")]
        public async Task<IActionResult> SendEmail(string toEmail)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            MailRequest mailRequest = new MailRequest();
            mailRequest.ToEmail = toEmail;
            mailRequest.Subject = "Mail Subject SendEmailAsync";
            mailRequest.Body = "Mail Body SendEmailAsync";
            await _emailService.SendEmailAsync(mailRequest);
            return Ok();
        }

        [HttpPost("/SendEmailWithHtml/{toEmail}")]
        public async Task<IActionResult> SendEmailWithHtml(string toEmail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            MailRequest mailRequest = new MailRequest();
            mailRequest.ToEmail = toEmail;
            mailRequest.Subject = "Mail Subject SendEmailAsync";
            mailRequest.Body = "<h1 style =\"color:red;\" >Mail Body SendEmailAsync! </h1>";
            await _emailService.SendEmailAsync(mailRequest);
            return Ok();
        }

        [HttpPost("/SendEmailWithAttachment/{toEmail}")]
        public async Task<IActionResult> SendEmailWithAttachment(string toEmail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            MailRequest mailRequest = new MailRequest();
            mailRequest.ToEmail = toEmail;
            mailRequest.Subject = "Mail Subject SendEmailAsync";
            mailRequest.Body = "<h1 style =\"color:red;\" >Mail Body SendEmailAsync! </h1>";
            await _emailService.SendEmailWithAttachmentAsync(mailRequest);
            return Ok();
        }
    }
}
