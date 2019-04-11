using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.WPF.Infrastructure
{
    interface ICloseNotification
    {
        event EventHandler<EventArgs<bool>> Closed;

        void OnViewClosed(object sender, EventArgs e);
    }
}
