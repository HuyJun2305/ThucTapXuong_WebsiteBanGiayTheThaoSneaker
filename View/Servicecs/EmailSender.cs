using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using View.IServices;

namespace View.Servicecs
{
    public class EmailSender : IEmailSender
    {
        private readonly string _emailFrom;
        private readonly string _emailPassword;
        private readonly string _smtpServer;
        private readonly int _smtpPort;

        public EmailSender(IConfiguration configuration)
        {
            _emailFrom = configuration["EmailSettings:EmailFrom"];
            _emailPassword = configuration["EmailSettings:EmailPassword"];
            _smtpServer = configuration["EmailSettings:SmtpServer"];
            _smtpPort = int.Parse(configuration["EmailSettings:SmtpPort"]);
        }

        public async Task SendEmailAsync( string subject, string message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("ShoseShop", _emailFrom));
            emailMessage.To.Add(new MailboxAddress("123", "xdug94@gmail.com"));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart("plain") { Text = "Hello, this is a test email." };

            using (var client = new SmtpClient())
            {
                client.Connect(_smtpServer, _smtpPort, SecureSocketOptions.StartTls);
                client.Authenticate(_emailFrom, _emailPassword);
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                await client.ConnectAsync(_smtpServer, _smtpPort, MailKit.Security.SecureSocketOptions.StartTls);
                await client.AuthenticateAsync(_emailFrom, _emailPassword);
                await client.SendAsync(emailMessage);
                await client.DisconnectAsync(true);
            }
        }
    }
}
