using System;
using System.Collections.Generic;
using System.Linq;
using MailSender.lib.Entityes;
using MailSender.lib.Services.Interfaces;

namespace MailSender.lib.Services
{
    public class SendersDataInMemory : ISendersData
    {
        private readonly List<Sender> _Senders = new List<Sender>();

        public IEnumerable<Sender> GetAll() => _Senders;

        public Sender GetById(int id) => _Senders.FirstOrDefault(e => e.Id == id);

        public void Add(Sender sender)
        {
            if (sender is null) throw new ArgumentNullException(nameof(sender));
            if (_Senders.Contains(sender)) return;

            sender.Id = _Senders.Count == 0 ? 1 : _Senders.Max(e => e.Id) + 1;
            _Senders.Add(sender);
        }

        public void Edit(Sender item)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));

            var db_item = GetById(item.Id);
            if (db_item is null) return;

            db_item.Name = item.Name;
            db_item.EmailAddress = item.EmailAddress;
        }

        public void Remove(int id)
        {
            var db_sender = GetById(id);
            if (db_sender is null) return;
            _Senders.Remove(db_sender);
        }

        public void SaveChanges() { }
    }
}