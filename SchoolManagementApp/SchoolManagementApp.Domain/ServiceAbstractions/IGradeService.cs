using SchoolManagementApp.Domain.Models;
using SchoolManagementApp.Domain.Models.StudentRelated;
using System.Collections.ObjectModel;

namespace SchoolManagementApp.Domain.ServiceAbstractions
{
    public interface IGradeService : ICollectionService<Grade>
    {
        ObservableCollection<Grade> GradeList { get; set; }

        ObservableCollection<Grade> GetStudentGrades(Student student);

    }
}
