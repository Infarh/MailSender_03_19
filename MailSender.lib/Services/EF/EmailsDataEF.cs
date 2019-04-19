using System.Collections.Generic;
using System.Linq;
using MailSender.lib.Data.EF;
using MailSender.lib.Entityes;
using MailSender.lib.Services.Interfaces;

namespace MailSender.lib.Services.EF
{
    public class EmailsDataEF : IEmailsData
    {

        private readonly MailSenderDB _db;

        public EmailsDataEF(MailSenderDB db) => _db = db;

        public IEnumerable<Email> GetAll() => _db.Emails.AsEnumerable();

        public Email GetById(int Id) => _db.Emails.FirstOrDefault(i => i.Id == Id);

        public void Add(Email Item) => _db.Emails.Add(Item);

        public void Edit(Email Item)
        {
            var db_item = GetById(Item.Id);
            if (db_item is null) return;

            db_item.Body = Item.Body;
            db_item.Subject = Item.Subject;
        }

        public void Remove(int Id)
        {
            var item = GetById(Id);
            if (item is null) return;
            _db.Emails.Remove(item);
        }

        public void SaveChanges() => _db.SaveChanges();
    }
}