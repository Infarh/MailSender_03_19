using System.Collections.Generic;
using System.Linq;
using MailSender.lib.Data.EF;
using MailSender.lib.Entityes;
using MailSender.lib.Services.Interfaces;

namespace MailSender.lib.Services.EF
{
    public class ServersDataEF : DataEF<Server>, IServersData
    {
        public ServersDataEF(MailSenderDB db) : base(db) { }

        public override void Edit(Server Item)
        {
            var server = GetById(Item.Id);
            if(server is null) return;

            server.Address = Item.Address;
            server.Port = Item.Port;
            server.UseSSL = Item.UseSSL;
            server.UserName = Item.UserName;
            server.Password = Item.Password;
        }
    }
}