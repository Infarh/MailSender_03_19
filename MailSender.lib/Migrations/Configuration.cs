using MailSender.lib.Entityes;

namespace MailSender.lib.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Data.EF.MailSenderDB>
    {
        public Configuration() => AutomaticMigrationsEnabled = true;

        protected override void Seed(Data.EF.MailSenderDB context)
        {
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
                new Email { Subject = "Заголовок письма 1", Body = "Текст пиьма 1" },
                new Email { Subject = "Заголовок письма 2", Body = "Текст пиьма 2" },
                new Email { Subject = "Заголовок письма 3", Body = "Текст пиьма 3" },
                new Email { Subject = "Заголовок письма 4", Body = "Текст пиьма 4" }
                );

            context.Senders.AddOrUpdate(sender => sender.EmailAddress,
                new Sender { Name = "Иванов", EmailAddress = "ivanow@yandex.ru" },
                new Sender { Name = "Петров", EmailAddress = "petrov@yandex.ru" },
                new Sender { Name = "Сидоров", EmailAddress = "sidorov@yandex.ru" }
                );

            context.Recipients.AddOrUpdate(sender => sender.EmailAddress,
                new Recipient { Name = "Ivanov", EmailAddress = "ivanow@yandex.ru" },
                new Recipient { Name = "Petrov", EmailAddress = "petrov@yandex.ru" },
                new Recipient { Name = "Sidorov", EmailAddress = "sidorov@yandex.ru" }
            );

            context.SaveChanges();

            if (!context.EmailList.Any())
            {
                var first_email = new EmailList { Name = "First", Emails = context.Emails.OrderBy(e => e.Id).Take(2).ToArray() };
                context.EmailList.AddOrUpdate(list => list.Name, first_email);

                var second_email = new EmailList { Name = "Second", Emails = context.Emails.OrderBy(e => e.Id).Skip(2).Take(2).ToArray() };
                context.EmailList.AddOrUpdate(list => list.Name, second_email);
            }
            context.SaveChanges();

            if (!context.RecipientsList.Any())
            {
                var first_list = new RecipientsList { Name = "First", Recipients = context.Recipients.OrderBy(r => r.Id).Take(1).ToArray() };
                context.RecipientsList.AddOrUpdate(list => list.Name, first_list);

                var second_list = new RecipientsList { Name = "Second", Recipients = context.Recipients.OrderBy(r => r.Id).Skip(1).Take(2).ToArray() };
                context.RecipientsList.AddOrUpdate(list => list.Name, second_list);
            }
            context.SaveChanges();

            if (!context.SchedulerTasks.Any())
            {
                var first_task = new SchedulerTask
                {
                    Time = DateTime.Now.AddHours(5),
                    Emails = context.EmailList.OrderBy(e => e.Id).Skip(0).First(),
                    Recipients = context.RecipientsList.OrderBy(r => r.Id).Skip(0).First(),
                    Server = context.Servers.OrderBy(s => s.Id).Skip(0).First(),
                    Sender = context.Senders.OrderBy(s => s.Id).Skip(0).First(),
                };
                context.SchedulerTasks.AddOrUpdate(first_task);

                var second_task = new SchedulerTask
                {
                    Time = DateTime.Now.AddHours(7),
                    Emails = context.EmailList.OrderBy(e => e.Id).Skip(1).First(),
                    Recipients = context.RecipientsList.OrderBy(r => r.Id).Skip(1).First(),
                    Server = context.Servers.OrderBy(s => s.Id).Skip(1).First(),
                    Sender = context.Senders.OrderBy(s => s.Id).Skip(1).First(),
                };
                context.SchedulerTasks.AddOrUpdate(second_task);
            }
        }
    }
}
