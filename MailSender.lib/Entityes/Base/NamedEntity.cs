using System.ComponentModel.DataAnnotations;

namespace MailSender.lib.Entityes.Base
{
    public abstract class NamedEntity : Entity
    {
        [Required]
        //[MinLength(3)]
        //[MaxLength(255)]
        public virtual string Name { get; set; }
    }
}