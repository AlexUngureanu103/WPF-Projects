using SchoolManagementApp.Domain.Models;
using System.Collections.ObjectModel;

namespace SchoolManagementApp.Domain.ServiceAbstractions
{
    public interface IStudentService : ICollectionService<Student>
    {
        ObservableCollection<Student> StudentList { get; set; }

        string errorMessage { get; }

        ObservableCollection<Student> GetStudentsByClassId(int classId);

        Student GetStudentByUserId(User user);
    }
}
