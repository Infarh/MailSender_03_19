using MailSender.lib.Entityes;

namespace MailSender.lib.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Data.EF.MailSenderDB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Data.EF.MailSenderDB context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.Servers.AddOrUpdate(server => server.Address,
                new Server
                {
                    Address = "smtp.yandex.ru",
                    Port = 25,
                    UseSSL = true,
                    Name = "Яндекс",
                    UserName = "user",
                    Password = "password"
                },
                new Server
                {
                    Address = "smtp.mail.ru",
                    Port = 25,
                    UseSSL = true,
                    Name = "Mail.ru",
                    UserName = "user",
                    Password = "password"
                },
                new Server
                {
                    Address = "smtp.gmail.com",
                    Port = 25,
                    UseSSL = true,
                    Name = "Gooooogle.com",
                    UserName = "user",
                    Password = "password"
                });

            context.Emails.AddOrUpdate(email => email.Subject,
                new Email{ Subject = "Заголовок письма 1", Body = "Текст пиьма 1" },
                new Email{ Subject = "Заголовок письма 2", Body = "Текст пиьма 2" },
                new Email{ Subject = "Заголовок письма 3", Body = "Текст пиьма 3" },
                new Email{ Subject = "Заголовок письма 4", Body = "Текст пиьма 4" }
                );


        }
    }
}
