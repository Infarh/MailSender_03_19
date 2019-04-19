using System.Collections.Generic;
using System.Linq;
using MailSender.lib.Data.EF;
using MailSender.lib.Entityes;
using MailSender.lib.Services.Interfaces;

namespace MailSender.lib.Services.EF
{
    public class EmailListsDataEF : DataEF<EmailList>, IEmailListsData
    {
        public EmailListsDataEF(MailSenderDB db) : base(db) { }

        public override void Edit(EmailList Item)
        {
            var db_item = GetById(Item.Id);
            if(db_item is null) return;

            db_item.Name = Item.Name;
            db_item.Emails = Item.Emails;
        }
    }
}