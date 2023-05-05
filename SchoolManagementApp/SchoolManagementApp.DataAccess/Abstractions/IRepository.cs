using SchoolManagementApp.DataAccess.Models;
using System.Collections.Generic;

namespace SchoolManagementApp.DataAccess.Abstractions
{
    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();

        T GetById(int entityId);

        void Add(T entity);

        void Update(T entity);

        void Delete(int entityId);

        void Remove(T entity);
    }
}
