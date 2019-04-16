﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailSender.lib.Entityes;
using MailSender.lib.Migrations;

namespace MailSender.lib.Data.EF
{
    public class MailSenderDB : DbContext
    {
        static MailSenderDB()
        {
            //System.Data.Entity.Database.SetInitializer(new CreateDatabaseIfNotExists<MailSenderDB>());
            //System.Data.Entity.Database.SetInitializer(new DropCreateDatabaseAlways<MailSenderDB>()); // Отладочный
            //System.Data.Entity.Database.SetInitializer(new System.Data.Entity.DropCreateDatabaseIfModelChanges<MailSenderDB>());
            //System.Data.Entity.Database.SetInitializer(new System.Data.Entity.NullDatabaseInitializer<MailSenderDB>());
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MailSenderDB, Configuration>());
        }


        public DbSet<Server> Servers { get; set; }

        public DbSet<Sender> Senders { get; set; }

        public DbSet<Recipient> Recipients { get; set; }

        public DbSet<SchedulerTask> SchedulerTasks { get; set; }

        public DbSet<RecipientsList> RecipientsList { get; set; }

        public DbSet<EmailList> EmailList { get; set; }

        public MailSenderDB() : base("name=MailSenderDB") { }

        public MailSenderDB(string ConnectionString) : base(ConnectionString) { }
    }
}
