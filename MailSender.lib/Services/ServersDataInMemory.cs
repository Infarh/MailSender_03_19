using System;
using System.Collections.Generic;
using System.Linq;
using MailSender.lib.Entityes;
using MailSender.lib.Services.Interfaces;

namespace MailSender.lib.Services
{
    public class ServersDataInMemory : IServersData
    {
        private readonly List<Server> _Servers = new List<Server>();

        public IEnumerable<Server> GetAll() => _Servers;

        public Server GetById(int id) => _Servers.FirstOrDefault(e => e.Id == id);

        public void Add(Server server)
        {
            if (server is null) throw new ArgumentNullException(nameof(server));
            if (_Servers.Contains(server)) return;

            server.Id = _Servers.Count == 0 ? 1 : _Servers.Max(e => e.Id) + 1;
            _Servers.Add(server);
        }

        public void Edit(Server item)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));

            var db_item = GetById(item.Id);
            if (db_item is null) return;

            db_item.Name = item.Name;
            db_item.Address = item.Address;
            db_item.UseSSL = item.UseSSL;
            db_item.UserName = item.UserName;
            db_item.Password = item.Password;
        }

        public void Remove(int id)
        {
            var db_email = GetById(id);
            if (db_email is null) return;
            _Servers.Remove(db_email);
        }

        public void SaveChanges() { }
    }
}