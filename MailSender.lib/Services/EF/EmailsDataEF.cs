using System.Collections.Generic;
using System.Linq;
using MailSender.lib.Data.EF;
using MailSender.lib.Entityes;
using MailSender.lib.Services.Interfaces;

namespace MailSender.lib.Services.EF
{
    public class EmailsDataEF : DataEF<Email>, IEmailsData
    {
        public EmailsDataEF(MailSenderDB db) : base(db) { }

        public override void Edit(Email Item)
        {
            var db_item = GetById(Item.Id);
            if (db_item is null) return;

            db_item.Body = Item.Body;
            db_item.Subject = Item.Subject;
        }
    }
}