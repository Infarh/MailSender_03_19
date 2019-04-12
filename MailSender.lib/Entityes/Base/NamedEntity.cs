namespace MailSender.lib.Entityes.Base
{
    public abstract class NamedEntity : Entity
    {
        public virtual string Name { get; set; }
    }
}