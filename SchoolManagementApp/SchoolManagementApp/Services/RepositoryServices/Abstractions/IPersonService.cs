using SchoolManagementApp.DataAccess.Models;
using System.Collections.ObjectModel;

namespace SchoolManagementApp.Services.RepositoryServices.Abstractions
{
    public interface IPersonService : ICollectionService<Person>
    {
        ObservableCollection<Person> PersonList { get; set; }
    }
}
