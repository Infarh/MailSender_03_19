using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailSender.lib.Entityes;

namespace MailSender.lib.Services.Interfaces
{
    public interface IRecipientsData
    {
        IEnumerable<Recipient> GetItems();

        Recipient GetItemById(int id);

        void Edit(Recipient item);
    }
}
