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
        private List<Email> _Emails = new List<Email>();

        public IEnumerable<Email> GetAll() => _Emails;

        public Email GetById(int id) => _Emails.FirstOrDefault(e => e.Id == id);

        public void Add(Email email)
        {
            if(email is null) throw new ArgumentNullException(nameof(email));
            if(_Emails.Contains(email)) return;

            email.Id = _Emails.Count == 0 ? 1 : _Emails.Max(e => e.Id) + 1;
            _Emails.Add(email);
        }

        public void Edit(Email email)
        {
            if(email is null) throw new ArgumentNullException(nameof(email));

            var db_email = GetById(email.Id);
            if(db_email is null) return;

            db_email.Subject = email.Subject;
            db_email.Body = email.Body;
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
