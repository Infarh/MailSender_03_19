using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailSender.lib.Data.EF;
using MailSender.lib.Entityes.Base;
using MailSender.lib.Services.Interfaces;

namespace MailSender.lib.Services.EF
{
    public abstract class DataEF<T> : IDataService<T> where T : Entity
    {
        private readonly MailSenderDB _db;
        private readonly DbSet<T> _Table;

        protected DataEF(MailSenderDB db)
        {
            _db = db;
            _Table = _db.Set<T>();
        }

        public IEnumerable<T> GetAll() => _Table.AsEnumerable();

        public T GetById(int id) => _Table.FirstOrDefault(item => item.Id == id);

        public void Add(T item) => _Table.Add(item);

        public abstract void Edit(T item);

        public void Remove(int id)
        {
            var item = GetById(id);
            if(item is null) return;
            _Table.Remove(item);
        }

        public void SaveChanges() => _db.SaveChanges();
    }
}
