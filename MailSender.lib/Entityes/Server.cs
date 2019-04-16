using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using MailSender.lib.Entityes.Base;

namespace MailSender.lib.Entityes
{
    [Table("Servers")]
    public class Server : NamedEntity
    {
        public string Address { get; set; }

        [DefaultValue(25)]
        public int Port { get; set; } = 25;

        public bool UseSSL { get; set; } = true;

        public string UserName { get; set; }
        public string Password { get; set; }
    }
}