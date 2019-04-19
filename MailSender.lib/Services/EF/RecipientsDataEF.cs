using System.Collections.Generic;
using System.Linq;
using MailSender.lib.Data.EF;
using MailSender.lib.Entityes;
using MailSender.lib.Services.Interfaces;

namespace MailSender.lib.Services.EF
{
    public class RecipientsDataEF : IRecipientsData
    {

        private readonly MailSenderDB _db;

        public RecipientsDataEF(MailSenderDB db) => _db = db;

        public IEnumerable<Recipient> GetAll() => _db.Recipients.AsEnumerable();

        public Recipient GetById(int Id) => _db.Recipients.FirstOrDefault(i => i.Id == Id);

        public void Add(Recipient Item) => _db.Recipients.Add(Item);

        public void Edit(Recipient Item)
        {
            var db_item = GetById(Item.Id);
            if (db_item is null) return;

            db_item.Name = Item.Name;
            db_item.EmailAddress = Item.EmailAddress;
        }

        public void Remove(int Id)
        {
            var item = GetById(Id);
            if (item is null) return;
            _db.Recipients.Remove(item);
        }

        public void SaveChanges() => _db.SaveChanges();
    }
}