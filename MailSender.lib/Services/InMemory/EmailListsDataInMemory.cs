using System;
using MailSender.lib.Entityes;
using MailSender.lib.Services.InMemory;
using MailSender.lib.Services.Interfaces;

namespace MailSender.lib.Services
{
    public class EmailListsDataInMemory : DataInMemory<EmailList>, IEmailListsData
    {
        public override void Edit(EmailList item)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));

            var db_email_list = GetById(item.Id);
            if (db_email_list is null) return;

            db_email_list.Name = item.Name;
            db_email_list.Emails = item.Emails;
        }
    }
}