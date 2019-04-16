namespace MailSender.lib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmailLists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Emails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Subject = c.String(),
                        Body = c.String(),
                        EmailList_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EmailLists", t => t.EmailList_Id)
                .Index(t => t.EmailList_Id);
            
            CreateTable(
                "dbo.Recipients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        EmailAddress = c.String(),
                        RecipientsList_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RecipientsLists", t => t.RecipientsList_Id)
                .Index(t => t.RecipientsList_Id);
            
            CreateTable(
                "dbo.RecipientsLists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SchedulerTasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Time = c.DateTime(nullable: false),
                        Emails_Id = c.Int(),
                        Recipients_Id = c.Int(),
                        Sender_Id = c.Int(),
                        Server_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EmailLists", t => t.Emails_Id)
                .ForeignKey("dbo.RecipientsLists", t => t.Recipients_Id)
                .ForeignKey("dbo.Senders", t => t.Sender_Id)
                .ForeignKey("dbo.Servers", t => t.Server_Id)
                .Index(t => t.Emails_Id)
                .Index(t => t.Recipients_Id)
                .Index(t => t.Sender_Id)
                .Index(t => t.Server_Id);
            
            CreateTable(
                "dbo.Senders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmailAddress = c.String(),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Servers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Address = c.String(),
                        Port = c.Int(nullable: false),
                        UseSSL = c.Boolean(nullable: false),
                        UserName = c.String(),
                        Password = c.String(),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SchedulerTasks", "Server_Id", "dbo.Servers");
            DropForeignKey("dbo.SchedulerTasks", "Sender_Id", "dbo.Senders");
            DropForeignKey("dbo.SchedulerTasks", "Recipients_Id", "dbo.RecipientsLists");
            DropForeignKey("dbo.SchedulerTasks", "Emails_Id", "dbo.EmailLists");
            DropForeignKey("dbo.Recipients", "RecipientsList_Id", "dbo.RecipientsLists");
            DropForeignKey("dbo.Emails", "EmailList_Id", "dbo.EmailLists");
            DropIndex("dbo.SchedulerTasks", new[] { "Server_Id" });
            DropIndex("dbo.SchedulerTasks", new[] { "Sender_Id" });
            DropIndex("dbo.SchedulerTasks", new[] { "Recipients_Id" });
            DropIndex("dbo.SchedulerTasks", new[] { "Emails_Id" });
            DropIndex("dbo.Recipients", new[] { "RecipientsList_Id" });
            DropIndex("dbo.Emails", new[] { "EmailList_Id" });
            DropTable("dbo.Servers");
            DropTable("dbo.Senders");
            DropTable("dbo.SchedulerTasks");
            DropTable("dbo.RecipientsLists");
            DropTable("dbo.Recipients");
            DropTable("dbo.Emails");
            DropTable("dbo.EmailLists");
        }
    }
}
