using System;

namespace MailSender.lib.Entityes
{
    public class SchedulerTask
    {
        public int Id { get; set; }

        public DateTime Time { get; set; }

        public Sender Sender { get; set; }

        public RecipientsList Recipients { get; set; }

        public EmailList Emails { get; set; }
    }
}