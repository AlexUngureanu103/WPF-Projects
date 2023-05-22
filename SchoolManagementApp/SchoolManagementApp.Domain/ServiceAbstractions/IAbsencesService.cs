using SchoolManagementApp.Domain.Models;
using SchoolManagementApp.Domain.Models.StudentRelated;
using System.Collections.ObjectModel;

namespace SchoolManagementApp.Domain.ServiceAbstractions
{
    public interface IAbsencesService : ICollectionService<Absences>
    {
        ObservableCollection<Absences> AbsenceList { get; set; }

        string errorMessage { get; }

        ObservableCollection<Absences> GetStudentAbsences(Student student);

        ObservableCollection<Absences> GetStudentAbsences(Student student, CourseType course);

        void MotivateAbsence(Absences absence);
    }
}
