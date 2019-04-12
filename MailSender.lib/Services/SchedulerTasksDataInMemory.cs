using System;
using System.Collections.Generic;
using System.Linq;
using MailSender.lib.Entityes;
using MailSender.lib.Services.Interfaces;

namespace MailSender.lib.Services
{
    public class SchedulerTasksDataInMemory : ISchedulerTasksData
    {
        private readonly List<SchedulerTask> _Tasks = new List<SchedulerTask>();

        public IEnumerable<SchedulerTask> GetAll() => _Tasks;

        public SchedulerTask GetById(int id) => _Tasks.FirstOrDefault(e => e.Id == id);

        public void Add(SchedulerTask task)
        {
            if (task is null) throw new ArgumentNullException(nameof(task));
            if (_Tasks.Contains(task)) return;

            task.Id = _Tasks.Count == 0 ? 1 : _Tasks.Max(e => e.Id) + 1;
            _Tasks.Add(task);
        }

        public void Edit(SchedulerTask task)
        {
            if (task is null) throw new ArgumentNullException(nameof(task));

            var db_task = GetById(task.Id);
            if (db_task is null) return;

            db_task.Sender = task.Sender;
            db_task.Time = task.Time;
            db_task.Emails = task.Emails;
            db_task.Recipients = task.Recipients;
        }

        public void Remove(int id)
        {
            var db_task = GetById(id);
            if (db_task is null) return;
            _Tasks.Remove(db_task);
        }

        public void SaveChanges() { }
    }
}