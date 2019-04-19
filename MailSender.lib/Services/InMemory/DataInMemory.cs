using System;
using System.Collections.Generic;
using System.Linq;
using MailSender.lib.Entityes.Base;
using MailSender.lib.Services.Interfaces;

namespace MailSender.lib.Services.InMemory
{
    public abstract class DataInMemory<T> : IDataService<T>
        where T : Entity
    {
        protected readonly List<T> _Items = new List<T>();

        public IEnumerable<T> GetAll() => _Items;

        public T GetById(int id) => _Items.FirstOrDefault(e => e.Id == id);

        public void Add(T item)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));
            if (_Items.Contains(item)) return;

            item.Id = _Items.Count == 0 ? 1 : _Items.Max(e => e.Id) + 1;
            _Items.Add(item);
        }

        public abstract void Edit(T item);

        public void Remove(int id)
        {
            var item = GetById(id);
            if (item is null) return;
            _Items.Remove(item);
        }

        public void SaveChanges() { }
    }
}
