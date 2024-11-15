using System.Net.Mail;

namespace comision_api.Services
{
    public class SmtpConfig
    {
        private static SmtpClient smtp;
        

        public static SmtpClient GetSmtpClient(IConfiguration _configuration)
        {
            if (smtp == null)
            {
                smtp = new SmtpClient();
                smtp.Host = _configuration["EmailSettings:SmtpServer"];
                smtp.Port = int.Parse(_configuration["EmailSettings:SmtpPort"]);
                smtp.EnableSsl = bool.Parse(_configuration["EmailSettings:EnableSsl"]);
                smtp.Credentials = new System.Net.NetworkCredential(_configuration["EmailSettings:Username"],
                    _configuration["EmailSettings:Password"]);
            }
            return smtp;
        }
    }
}
