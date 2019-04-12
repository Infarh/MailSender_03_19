using System;
using System.Collections.Generic;
using System.Linq;
using MailSender.lib.Entityes;
using MailSender.lib.Services.Interfaces;

namespace MailSender.lib.Services
{
    public class SchedulerTasksDataInMemory : DataInMemory<SchedulerTask>, ISchedulerTasksData
    {
        public override void Edit(SchedulerTask task)
        {
            if (task is null) throw new ArgumentNullException(nameof(task));

            var db_task = GetById(task.Id);
            if (db_task is null) return;

            db_task.Sender = task.Sender;
            db_task.Time = task.Time;
            db_task.Emails = task.Emails;
            db_task.Recipients = task.Recipients;
        }
    }
}