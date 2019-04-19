using System.Collections.Generic;
using System.Linq;
using MailSender.lib.Data.EF;
using MailSender.lib.Entityes;
using MailSender.lib.Services.Interfaces;

namespace MailSender.lib.Services.EF
{
    public class ServersDataEf : IServersData
    {
        private readonly MailSenderDB _db;

        public ServersDataEf(MailSenderDB db) => _db = db;

        public IEnumerable<Server> GetAll() => _db.Servers.AsEnumerable();

        public Server GetById(int Id) => _db.Servers.FirstOrDefault(Server => Server.Id == Id);

        public void Add(Server Item) => _db.Servers.Add(Item);

        public void Edit(Server Item)
        {
            var server = GetById(Item.Id);
            if(server is null) return;

            server.Address = Item.Address;
            server.Port = Item.Port;
            server.UseSSL = Item.UseSSL;
            server.UserName = Item.UserName;
            server.Password = Item.Password;
        }

        public void Remove(int Id)
        {
            var item = GetById(Id);
            if(item is null) return;
            _db.Servers.Remove(item);
        }

        public void SaveChanges() => _db.SaveChanges();
    }
}