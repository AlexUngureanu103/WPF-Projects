using SchoolManagementApp.Domain.Models.StudentRelated;
using System.Collections.Generic;

namespace SchoolManagementApp.Domain.RepositoriesAbstractions
{
    public interface IAbsencesRepository : IRepository<Absences>
    {
        IEnumerable<Absences> GetStudentAbsences(int studentId);

        IEnumerable<Absences> GetStudentAbsences(int studentId, int courseId);

        void MotivateAbsence(int absenceId);
    }
}
