using System.Collections.Generic;
using System.Linq;
using MailSender.lib.Data.EF;
using MailSender.lib.Entityes;
using MailSender.lib.Services.Interfaces;

namespace MailSender.lib.Services.EF
{
    public class SendersDataEF : ISendersData
    {
        private readonly MailSenderDB _db;

        public SendersDataEF(MailSenderDB db) => _db = db;

        public IEnumerable<Sender> GetAll() => _db.Senders.AsEnumerable();

        public Sender GetById(int Id) => _db.Senders.FirstOrDefault(i => i.Id == Id);

        public void Add(Sender Item) => _db.Senders.Add(Item);

        public void Edit(Sender Item)
        {
            var db_item = GetById(Item.Id);
            if (db_item is null) return;

            db_item.Name = Item.Name;
            db_item.EmailAddress = Item.EmailAddress;
        }

        public void Remove(int Id)
        {
            var item = GetById(Id);
            if(item is null) return;
            _db.Senders.Remove(item);
        }  

        public void SaveChanges() => _db.SaveChanges();
    }
}