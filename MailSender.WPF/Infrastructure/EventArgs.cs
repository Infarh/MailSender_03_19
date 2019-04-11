using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.WPF.Infrastructure
{
    class EventArgs<T> : EventArgs
    {
        public T Arg { get; set; }

        public EventArgs() { }
        public EventArgs(T arg) => Arg = arg;

        public static implicit operator T(EventArgs<T> e) => e.Arg;
        public static implicit operator EventArgs<T>(T arg) => new EventArgs<T>(arg);
    }
}
