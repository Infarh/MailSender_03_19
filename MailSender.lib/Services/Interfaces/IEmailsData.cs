using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailSender.lib.Entityes;

namespace MailSender.lib.Services.Interfaces
{
    public interface IEmailsData
    {
        IEnumerable<Email> GetAll();

        Email GetById(int id);

        void Add(Email email);

        void Edit(Email email);

        void Remove(int id);

        void SaveChanges();
    }
}
