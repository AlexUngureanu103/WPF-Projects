using SchoolManagementApp.Domain.Models;
using SchoolManagementApp.Domain.Models.StudentRelated;
using System.Collections.ObjectModel;

namespace SchoolManagementApp.Domain.ServiceAbstractions
{
    public interface IClassService : ICollectionService<Class>
    {
        ObservableCollection<Class> ClassList { get; set; }

        string errorMessage { get; }

        Class GetClassByClassMasterId(Teacher teacher);
    }
}
