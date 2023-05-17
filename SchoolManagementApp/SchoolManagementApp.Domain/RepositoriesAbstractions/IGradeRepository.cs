using SchoolManagementApp.Domain.Models.StudentRelated;
using System.Collections.Generic;

namespace SchoolManagementApp.Domain.RepositoriesAbstractions
{
    public interface IGradeRepository : IRepository<Grade>
    {
        IEnumerable<Grade> GetStudentGrades(int studentId);
    }
}
