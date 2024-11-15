using System.Net.Mail;

namespace comision_api.Services
{
    public class EmailService
    {
        private static IConfiguration _configuration;
        private static SmtpClient smtp;
        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
            smtp = SmtpConfig.GetSmtpClient(configuration);
        }


        public bool sendEmail(string to, string subject, string body)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(_configuration["EmailSettings:Username"]);
                mail.To.Add(to);
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = true;
                smtp.Send(mail);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public async Task<bool> VerifyEmail(string name, string email, string url)
        {
            string verifyTemplate = Path.Combine(Directory.GetCurrentDirectory(), "src", "views", "EmailVerification.html");
            string htmlContent = await File.ReadAllTextAsync(verifyTemplate);
            htmlContent = htmlContent.Replace("{Link}", url);
            htmlContent = htmlContent.Replace("{Name}", name);
            return sendEmail(email, "Verifica tu correo", htmlContent);
        }
    }
}
