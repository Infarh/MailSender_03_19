using System;
using MailSender.lib.Entityes.Base;

namespace MailSender.lib.Entityes
{
    public class SchedulerTask : Entity
    {
        public DateTime Time { get; set; }

        public virtual Server Server { get; set; }

        public virtual Sender Sender { get; set; }

        public virtual RecipientsList Recipients { get; set; }

        public virtual EmailList Emails { get; set; }
    }
}