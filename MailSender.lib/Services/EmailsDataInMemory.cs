using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailSender.lib.Entityes;
using MailSender.lib.Services.Interfaces;

namespace MailSender.lib.Services
{
    public class EmailsDataInMemory : IEmailsData
    {
        private readonly List<Email> _Emails = new List<Email>();

        public IEnumerable<Email> GetAll() => _Emails;

        public Email GetById(int id) => _Emails.FirstOrDefault(e => e.Id == id);

        public void Add(Email item)
        {
            if(item is null) throw new ArgumentNullException(nameof(item));
            if(_Emails.Contains(item)) return;

            item.Id = _Emails.Count == 0 ? 1 : _Emails.Max(e => e.Id) + 1;
            _Emails.Add(item);
        }

        public void Edit(Email item)
        {
            if(item is null) throw new ArgumentNullException(nameof(item));

            var db_email = GetById(item.Id);
            if(db_email is null) return;

            db_email.Subject = item.Subject;
            db_email.Body = item.Body;
        }

        public void Remove(int id)
        {
            var db_email = GetById(id);
            if(db_email is null) return;
            _Emails.Remove(db_email);
        }

        public void SaveChanges() { }
    }
}
