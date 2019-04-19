using System.Collections.Generic;
using System.Linq;
using MailSender.lib.Data.EF;
using MailSender.lib.Entityes;
using MailSender.lib.Services.Interfaces;

namespace MailSender.lib.Services.EF
{
    public class SchedulerTasksDataEF : ISchedulerTasksData
    {

        private readonly MailSenderDB _db;

        public SchedulerTasksDataEF(MailSenderDB db) => _db = db;

        public IEnumerable<SchedulerTask> GetAll() => _db.SchedulerTasks.AsEnumerable();

        public SchedulerTask GetById(int Id) => _db.SchedulerTasks.FirstOrDefault(i => i.Id == Id);

        public void Add(SchedulerTask Item) => _db.SchedulerTasks.Add(Item);

        public void Edit(SchedulerTask Item)
        {
            var db_item = GetById(Item.Id);
            if (db_item is null) return;

            db_item.Server = Item.Server;
            db_item.Recipients = Item.Recipients;
            db_item.Sender = Item.Sender;
            db_item.Time = Item.Time;
            db_item.Emails = Item.Emails;
        }

        public void Remove(int Id)
        {
            var item = GetById(Id);
            if (item is null) return;
            _db.SchedulerTasks.Remove(item);
        }

        public void SaveChanges() => _db.SaveChanges();
    }
}