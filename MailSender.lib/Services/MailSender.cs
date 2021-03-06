﻿using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading;
using System.Threading.Tasks;

namespace MailSender.lib.Services
{
    public class MailSender
    {
        private readonly string _ServerAddress;
        private readonly int _Port;
        private readonly bool _SSL;
        private readonly string _Login;
        private readonly string _Password;

        public MailSender(string ServerAddress, int Port, bool SSL, string Login, string Password)
        {
            _ServerAddress = ServerAddress;
            _Port = Port;
            _SSL = SSL;
            _Login = Login;
            _Password = Password;
        }

        public void SendEmail(string Subject, string Body, string From, string To)
        {
            using (var msg = new MailMessage(From, To, Subject, Body))
                using (var client = new SmtpClient(_ServerAddress, _Port)
                {
                    EnableSsl = _SSL,
                    Credentials = new NetworkCredential(_Login, _Password)
                })
                {
                    client.Send(msg);
                }
        }

        public async Task SendEmailAsync(string Subject, string Body, string From, string To)
        {
            using (var msg = new MailMessage(From, To, Subject, Body))
            using (var client = new SmtpClient(_ServerAddress, _Port)
            {
                EnableSsl = _SSL,
                Credentials = new NetworkCredential(_Login, _Password)
            })
            {
                //client.Send(msg);
                await client.SendMailAsync(msg).ConfigureAwait(false);
            }
        }

        public void SendEmails(string Subject, string Body, string From, IEnumerable<string> To)
        {
            foreach (var to in To)
                SendEmail(Subject, Body, From, to);
        }

        public void SendEmailsParallel_Threads(string Subject, string Body, string From, IEnumerable<string> To)
        {
            foreach (var to in To)
            {
                //var tmp_to = to;
                //new Thread(() => SendEmail(Subject, Body, From, tmp_to)).Start();
                new Thread(recipient => SendEmail(Subject, Body, From, (string)recipient)).Start(to);
            }
        }

        public void SendEmailsParallel_ThreadPool(string Subject, string Body, string From, IEnumerable<string> To)
        {
            foreach (var to in To)
            {
                //var tmp_to = to;
                //ThreadPool.QueueUserWorkItem(p => SendEmail(Subject, Body, From, tmp_to));
                ThreadPool.QueueUserWorkItem(sender => SendEmail(Subject, Body, From, (string)sender), to);
            }
        }

        //public async Task SendEmailsAsync(string Subject, string Body, string From, IEnumerable<string> To)
        //{
        //    foreach (var to in To)
        //        await SendEmailAsync(Subject, Body, From, to).ConfigureAwait(false);
        //}

        public async Task SendEmailsAsync(string Subject, string Body, string From, IEnumerable<string> To)
        {
            var tasks = To.Select(to => SendEmailAsync(Subject, Body, From, to));
            await Task.WhenAll(tasks).ConfigureAwait(false);
        }
    }
}
