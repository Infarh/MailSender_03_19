using System.Collections.Generic;

namespace MailSender.lib.Services.Interfaces
{
    public interface IDataService<T>
    {
        IEnumerable<T> GetAll();

        T GetById(int id);

        void Add(T email);

        void Edit(T email);

        void Remove(int id);

        void SaveChanges();
    }
}