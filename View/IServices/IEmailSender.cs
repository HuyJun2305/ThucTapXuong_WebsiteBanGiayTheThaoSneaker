namespace View.IServices
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string subject, string message);
    }
}
