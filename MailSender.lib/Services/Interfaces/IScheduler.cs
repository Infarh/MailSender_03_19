using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MailSender.lib.Entityes;

namespace MailSender.lib.Services.Interfaces
{
    public interface ISendingMailScheduler
    {
        IEnumerable<SchedulerTask> Tasks { get; }

        void InitializeAsync();

        SchedulerTask Add(EmailList Emails, Sender Sender, Server Server, RecipientsList SendingList, DateTime Time);
    }
}