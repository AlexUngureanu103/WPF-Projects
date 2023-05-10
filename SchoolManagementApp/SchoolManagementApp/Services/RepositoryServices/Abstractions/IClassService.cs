using SchoolManagementApp.DataAccess.Models.StudentRelated;
using System.Collections.ObjectModel;

namespace SchoolManagementApp.Services.RepositoryServices.Abstractions
{
    public interface IClassService : ICollectionService<Class>
    {
        ObservableCollection<Class> ClassList { get; set; }
    }
}
