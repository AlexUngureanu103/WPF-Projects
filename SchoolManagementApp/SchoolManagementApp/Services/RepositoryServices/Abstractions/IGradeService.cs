using SchoolManagementApp.DataAccess.Models;
using SchoolManagementApp.DataAccess.Models.StudentRelated;
using System.Collections.ObjectModel;

namespace SchoolManagementApp.Services.RepositoryServices.Abstractions
{
    internal interface IGradeService : ICollectionService<Grade>
    {
        ObservableCollection<Grade> GetStudentGrades(Student student);

    }
}
