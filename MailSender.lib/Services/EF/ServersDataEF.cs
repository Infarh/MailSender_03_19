using System.Collections.Generic;
using System.Linq;
using MailSender.lib.Data.EF;
using MailSender.lib.Entityes;
using MailSender.lib.Services.Interfaces;

namespace MailSender.lib.Services.EF
{
    public class ServersDataEF : IServersData
    {
        private readonly MailSenderDB _db;

        public ServersDataEF(MailSenderDB db)
        {
            _db = db;
        }

        public IEnumerable<Server> GetAll()
        {
            return _db.Servers.AsEnumerable();
        }

        public Server GetById(int id)
        {
            return _db.Servers.FirstOrDefault(server => server.Id == id);
        }

        public void Add(Server item)
        {
            _db.Servers.Add(item);
        }

        public void Edit(Server item)
        {
            var server = GetById(item.Id);

            server.Address = item.Address;
            server.Port = item.Port;
            server.UseSSL = item.UseSSL;
            server.UserName = item.UserName;
            server.Password = item.Password;
        }

        public void Remove(int id)
        {
            _db.Servers.Remove(GetById(id));
        }

        public void SaveChanges()
        {
            _db.SaveChanges();
        }
    }
}