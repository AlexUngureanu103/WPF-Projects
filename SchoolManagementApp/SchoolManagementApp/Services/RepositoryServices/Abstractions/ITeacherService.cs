using SchoolManagementApp.DataAccess.Models;
using System.Collections.ObjectModel;

namespace SchoolManagementApp.Services.RepositoryServices.Abstractions
{
    public interface ITeacherService : ICollectionService<Teacher>
    {
        ObservableCollection<Teacher> TeacherList { get; set; }
    }
}
