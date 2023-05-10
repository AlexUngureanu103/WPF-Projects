using SchoolManagementApp.DataAccess.Models.StudentRelated;
using System.Collections.Generic;

namespace SchoolManagementApp.DataAccess.Abstractions
{
    public interface IGradeRepository : IRepository<Grade>
    {
        IEnumerable<Grade> GetStudentGrades(int studentId);
    }
}
