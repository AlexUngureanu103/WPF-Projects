using SchoolManagementApp.DataAccess.Models.StudentRelated;
using System.Collections.Generic;

namespace SchoolManagementApp.DataAccess.Abstractions
{
    public interface IAbsencesRepository : IRepository<Absences>
    {
        IEnumerable<Absences> GetStudentAbsences(int studentId);
    }
}
