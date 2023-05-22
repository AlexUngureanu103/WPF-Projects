using SchoolManagementApp.Domain.Models;
using System.Collections.ObjectModel;

namespace SchoolManagementApp.Domain.ServiceAbstractions
{
    public interface IPersonService : ICollectionService<Person>
    {
        ObservableCollection<Person> PersonList { get; set; }

        string errorMessage { get; }
    }
}
