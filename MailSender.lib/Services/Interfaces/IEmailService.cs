using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MailSender.lib.Services.Interfaces
{
    public interface IEmailService
    {
        IEmailSender GetSender(string ServerAddress, int Port, bool SSL, string Login, string Password);
    }

    public interface IEmailSender
    {
        void SendEmail(string Subject, string Body, string From, string To);
        Task SendEmailAsync(string Subject, string Body, string From, string To, CancellationToken Cancel);

        void SendEmails(string Subject, string Body, string From, IEnumerable<string> Recipients);
        Task SendEmailsAsync(string Subject, string Body, string From, IEnumerable<string> Recipients, CancellationToken Cancel);
    }
}