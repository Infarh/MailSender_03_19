using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.lib.Entityes.Base
{
    public class Human
    {
        public int Id { get; set; }

        public virtual string Name { get; set; }

        public virtual string EmailAddress { get; set; }
    }
}
