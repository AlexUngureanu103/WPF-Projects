using System.Collections.Generic;
using System.Linq;

namespace SchoolManagementApp.DataAccess.Abstractions
{
    internal interface IRepository<T>
    {
        IEnumerable<T> GetAll();

        T GetById(int entityId);

        void Add(T entity);

        void Update(T entity);

        void Delete(int entityId);
    }
}
