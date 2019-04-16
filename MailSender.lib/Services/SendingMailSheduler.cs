using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MailSender.lib.Entityes;
using MailSender.lib.Services.Interfaces;

namespace MailSender.lib.Services
{
    public class SendingMailSheduler : ISendingMailScheduler
    {
        private readonly ISchedulerTasksData _SchedulerTasksData;
        private readonly IEmailService _EmailService;

        public IEnumerable<SchedulerTask> Tasks => _SchedulerTasksData.GetAll();

        public SendingMailSheduler(ISchedulerTasksData SchedulerTasksData, IEmailService EmailService)
        {
            _SchedulerTasksData = SchedulerTasksData;
            _EmailService = EmailService;
        }

        public SchedulerTask Add(EmailList Emails, Sender Sender, Server Server, RecipientsList SendingList, DateTime Time)
        {
            var task = new SchedulerTask
            {
                Emails = Emails,
                Sender = Sender,
                Server = Server,
                SendingList = SendingList,
                Time = Time
            };

            _SchedulerTasksData.Add(task);

            InitializeAsync();

            return task;
        }

        private CancellationTokenSource _InitializeAsyncCancellation = new CancellationTokenSource();
        public async void InitializeAsync()
        {
            var cancellation = new CancellationTokenSource();
            Interlocked.Exchange(ref _InitializeAsyncCancellation, cancellation)?.Cancel();

            var cancel = cancellation.Token;

            while (await ExecuteFirstTask(cancel)) { }
        }

        private async Task<bool> ExecuteFirstTask(CancellationToken Cancel)
        {
            Cancel.ThrowIfCancellationRequested();
            var task = _SchedulerTasksData
                .GetAll()
                .OrderBy(t => t.Time)
                .FirstOrDefault();

            if (task is null) return false;

            var delta = task.Time - DateTime.Now;

            await Task.Delay(delta, Cancel);

            Cancel.ThrowIfCancellationRequested();

            await ExecuteTask(task, Cancel);

            return true;
        }

        private async Task ExecuteTask(SchedulerTask task, CancellationToken Cancel)
        {
            var server = task.Server;
            var sender = _EmailService.GetSender(server.Address, server.Port, server.UseSSL, server.UserName, server.Password);

            foreach (var email in task.Emails.Emails)
                await sender.SendEmailsAsync(email.Subject, email.Body,
                    task.Sender.EmailAddress,
                    task.SendingList.Recipients.Select(recipient => recipient.EmailAddress),
                    Cancel);
        }
    }
}
