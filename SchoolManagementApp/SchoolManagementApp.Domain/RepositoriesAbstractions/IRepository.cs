﻿using SchoolManagementApp.Domain.Models;
using System;
using System.Collections.Generic;

namespace SchoolManagementApp.Domain.RepositoriesAbstractions
{
    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();

        T GetById(int entityId);

        void Add(T entity);

        void Update(T entity);

        void Delete(int entityId);

        void Remove(T entity);

        bool Any(Func<T, bool> expression);
    }
}
