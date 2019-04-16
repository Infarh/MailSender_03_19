using System;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using GalaSoft.MvvmLight.Ioc;
using MailSender.lib.Data.EF;

namespace MailSender.WPF
{
    public partial class App
    {
        public static bool IsInDebugModel { get; private set; } = true;

        protected override void OnStartup(StartupEventArgs e)
        {
            IsInDebugModel = false;
            base.OnStartup(e);

            using (var db = new MailSenderDB())
            {
                db.Database.Log = log_str => Debug.WriteLine($"EF({DateTime.Now:hh:mm:ss.ttt}): {log_str}");

                var servers_ru = db.Servers.Where(server => server.Address.EndsWith(".ru"));

                foreach (var server in servers_ru)
                {
                    Debug.WriteLine(server.Name);

                    server.Port = 433;

                    server.UserName += "123";
                }


                db.SaveChanges();
            }
        }
    }
}
