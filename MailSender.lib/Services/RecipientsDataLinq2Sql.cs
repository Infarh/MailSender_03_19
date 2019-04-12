using System;
using System.Collections.Generic;
using System.Linq;
using MailSender.lib.Data.linq2sql;
using MailSender.lib.Entityes;
using MailSender.lib.Services.Interfaces;

namespace MailSender.lib.Services
{
    public class RecipientsDataLinq2Sql : IRecipientsData
    {
        private readonly MailSenderDBDataContext _Context;

        public RecipientsDataLinq2Sql(MailSenderDBDataContext Context)
        {
            _Context = Context;
        }

        public IEnumerable<Recipient> GetAll()
        {
            var db_recipients = _Context.Recipients;
            return db_recipients.Select(r => new Recipient
            {
                Id = r.Id,
                Name = r.Name,
                EmailAddress = r.Email
            });
        }

        public Recipient GetById(int id)
        {
            var db_recipient = _Context.Recipients.FirstOrDefault(r => r.Id == id);
            if (db_recipient is null)
                return null;
            return new Recipient
            {
                Id = db_recipient.Id,
                Name = db_recipient.Name,
                EmailAddress = db_recipient.Email
            };
        }

        public void Add(Recipient item)
        {
            throw new NotImplementedException();
        }

        public void Edit(Recipient item)
        {
            var db_recipient = _Context.Recipients.FirstOrDefault(r => r.Id == item.Id);
            if(db_recipient is null) return;

            db_recipient.Name = item.Name;
            db_recipient.Email = item.EmailAddress;

            _Context.SubmitChanges();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
