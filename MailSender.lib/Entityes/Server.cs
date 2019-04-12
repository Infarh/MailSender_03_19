using MailSender.lib.Entityes.Base;

namespace MailSender.lib.Entityes
{
    public class Server : NamedEntity
    {
        public string Address { get; set; }
        public int Port { get; set; } = 25;
        public bool UseSSL { get; set; } = true;

        public string UserName { get; set; }
        public string Password { get; set; }
    }
}