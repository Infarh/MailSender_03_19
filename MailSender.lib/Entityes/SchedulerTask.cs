using System;
using MailSender.lib.Entityes.Base;

namespace MailSender.lib.Entityes
{
    public class SchedulerTask : Entity
    {
        public DateTime Time { get; set; }

        public Sender Sender { get; set; }

        public RecipientsList Recipients { get; set; }

        public EmailList Emails { get; set; }
    }
}