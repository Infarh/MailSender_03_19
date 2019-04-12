using MailSender.lib.Entityes.Base;

namespace MailSender.lib.Entityes
{
    public class Email : Entity
    {
        public string Subject { get; set; }

        public string Body { get; set; }
    }
}