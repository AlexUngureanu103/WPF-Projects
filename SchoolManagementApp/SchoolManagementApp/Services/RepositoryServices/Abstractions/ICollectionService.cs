﻿using System.Collections.ObjectModel;

namespace SchoolManagementApp.Services.RepositoryServices.Abstractions
{
    public interface ICollectionService<T>
    {
        ObservableCollection<T> GetAll();

        void Add(T entity);

        void Edit(T entity);

        void Remove(T entity);
    }
}
