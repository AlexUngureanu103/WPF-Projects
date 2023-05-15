using SchoolManagementApp.DataAccess.Models;
using SchoolManagementApp.DataAccess.Models.StudentRelated;
using System.Collections.ObjectModel;

namespace SchoolManagementApp.Services.RepositoryServices.Abstractions
{
    public interface IGradeService : ICollectionService<Grade>
    {
        ObservableCollection<Grade> GradeList { get; set; }

        ObservableCollection<Grade> GetStudentGrades(Student student);

    }
}
