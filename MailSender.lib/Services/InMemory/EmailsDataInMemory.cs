using System;
using MailSender.lib.Entityes;
using MailSender.lib.Services.Interfaces;

namespace MailSender.lib.Services.InMemory
{
    public class EmailsDataInMemory : DataInMemory<Email>, IEmailsData
    {
        public override void Edit(Email item)
        {
            if(item is null) throw new ArgumentNullException(nameof(item));

            var db_email = GetById(item.Id);
            if(db_email is null) return;

            db_email.Subject = item.Subject;
            db_email.Body = item.Body;
        }
    }
}
