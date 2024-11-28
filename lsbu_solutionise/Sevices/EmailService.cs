using System.Net;
using System.Net.Mail;

namespace lsbu_solutionise.Sevices
{
    public class EmailService
    {
        private readonly IConfiguration _configuration;

       
        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendEmailAsync(string toEmail, string subject, string message)
        {
            
            var smtpClient = new SmtpClient("smtp-relay.brevo.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("80d85f001@smtp-brevo.com", "SXBrNTE8hVdJzbOP"),
                EnableSsl = true,
            };

            var mail = new MailMessage
            {
                From = new MailAddress("xassir@gmail.com"),
                Subject = subject,
                Body = message,
                IsBodyHtml = true
            };

            mail.To.Add(toEmail);

            smtpClient.Send(mail);

        }

    }
}
