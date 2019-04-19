using System.Collections.Generic;
using System.Linq;
using MailSender.lib.Data.EF;
using MailSender.lib.Entityes;
using MailSender.lib.Services.Interfaces;

namespace MailSender.lib.Services.EF
{
    public class SchedulerTasksDataEF : DataEF<SchedulerTask>, ISchedulerTasksData
    {
        public SchedulerTasksDataEF(MailSenderDB db) : base(db) { }

        public override void Edit(SchedulerTask Item)
        {
            var db_item = GetById(Item.Id);
            if (db_item is null) return;

            db_item.Server = Item.Server;
            db_item.Recipients = Item.Recipients;
            db_item.Sender = Item.Sender;
            db_item.Time = Item.Time;
            db_item.Emails = Item.Emails;
        }
    }
}