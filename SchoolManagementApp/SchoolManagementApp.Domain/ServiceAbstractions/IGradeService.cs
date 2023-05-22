using SchoolManagementApp.Domain.Models;
using SchoolManagementApp.Domain.Models.StudentRelated;
using System.Collections.ObjectModel;

namespace SchoolManagementApp.Domain.ServiceAbstractions
{
    public interface IGradeService : ICollectionService<Grade>
    {
        ObservableCollection<Grade> GradeList { get; set; }

        string errorMessage { get; set; }

        ObservableCollection<Grade> GetStudentGrades(Student student);

        ObservableCollection<Grade> GetStudentGrades(Student student, CourseType course);
    }
}
