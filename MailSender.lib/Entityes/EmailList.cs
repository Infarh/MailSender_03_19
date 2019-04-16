using System.Collections.Generic;
using MailSender.lib.Entityes.Base;

namespace MailSender.lib.Entityes
{
    public class EmailList : NamedEntity
    {
        public virtual ICollection<Email> Emails { get; set; } = new List<Email>();
    }
}