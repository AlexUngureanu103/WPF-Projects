using SchoolManagementApp.DataAccess.Models;
using SchoolManagementApp.DataAccess.Models.StudentRelated;
using System.Collections.ObjectModel;

namespace SchoolManagementApp.Services.RepositoryServices.Abstractions
{
    public interface IAbsencesService : ICollectionService<Absences>
    {
        ObservableCollection<Absences> AbsenceList { get; set; }

        ObservableCollection<Absences> GetStudentAbsences(Student student);
    }
}
