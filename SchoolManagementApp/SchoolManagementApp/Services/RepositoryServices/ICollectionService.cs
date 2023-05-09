using System.Collections.ObjectModel;

namespace SchoolManagementApp.Services.RepositoryServices
{
    internal interface ICollectionService<T>
    {
        ObservableCollection<T> GetAll();

        void Add(T entity);

        void Edit(T entity);

        void Remove(T entity);
    }
}
