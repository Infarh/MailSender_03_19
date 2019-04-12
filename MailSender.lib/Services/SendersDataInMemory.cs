using System;
using System.Collections.Generic;
using System.Linq;
using MailSender.lib.Entityes;
using MailSender.lib.Services.Interfaces;

namespace MailSender.lib.Services
{
    public class SendersDataInMemory : DataInMemory<Sender>, ISendersData
    {
        public override void Edit(Sender item)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));

            var db_item = GetById(item.Id);
            if (db_item is null) return;

            db_item.Name = item.Name;
            db_item.EmailAddress = item.EmailAddress;
        }
    }
}