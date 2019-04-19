using System.Collections.Generic;
using System.Linq;
using MailSender.lib.Data.EF;
using MailSender.lib.Entityes;
using MailSender.lib.Services.Interfaces;

namespace MailSender.lib.Services.EF
{
    public class EmailListsDataEF : IEmailListsData
    {
        private readonly MailSenderDB _db;

        public EmailListsDataEF(MailSenderDB db) => _db = db;

        public IEnumerable<EmailList> GetAll() => _db.EmailList.AsEnumerable();

        public EmailList GetById(int Id) => _db.EmailList.FirstOrDefault(i => i.Id == Id);

        public void Add(EmailList Item) => _db.EmailList.Add(Item);

        public void Edit(EmailList Item)
        {
            var db_item = GetById(Item.Id);
            if(db_item is null) return;

            db_item.Name = Item.Name;
            db_item.Emails = Item.Emails;
        }

        public void Remove(int Id)
        {
            var item = GetById(Id);
            if (item is null) return;
            _db.EmailList.Remove(item);
        }

        public void SaveChanges() => _db.SaveChanges();
    }
}