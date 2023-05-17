using SchoolManagementApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace SchoolManagementApp.DataAccess.Repositories
{
    public class RepositoryBase<T> where T : BaseEntity
    {
        protected readonly SchoolManagementDbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public RepositoryBase(SchoolManagementDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }

        public T GetById(int entityId)
        {
            return _dbSet.FirstOrDefault(entity => entity.Id == entityId);
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Update(T entity)
        {
            _dbSet.AddOrUpdate(entity);
        }

        public void Delete(int entityId)
        {
            var entity = GetById(entityId);
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            _dbSet.Remove(entity);
        }

        /// <summary>
        ///     This method will actually remove the row from the database.
        /// </summary>
        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return GetRecords().ToList();
        }

        public bool Any(Func<T, bool> expression)
        {
            return GetRecords().Any(expression);
        }

        protected IQueryable<T> GetRecords()
        {
            return _dbSet.AsQueryable<T>();
        }
    }
}
