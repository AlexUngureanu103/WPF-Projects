using SchoolManagementApp.DataAccess.Models;
using System.Collections.ObjectModel;

namespace SchoolManagementApp.Services.RepositoryServices.Abstractions
{
    public interface IStudentService : ICollectionService<Student>
    {
        ObservableCollection<Student> StudentList { get; set; }
    }
}
