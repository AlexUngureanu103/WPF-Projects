using SchoolManagementApp.Domain.Models.StudentRelated;
using System.Collections.Generic;

namespace SchoolManagementApp.Domain.RepositoriesAbstractions
{
    public interface IAverageGradeRepository : IRepository<AverageGrade>
    {
        IEnumerable<AverageGrade> GetStudentAverageGrades(int studentId);

        IEnumerable<AverageGrade> GetClassAverageGrades(int classId);

        AverageGrade GetStudentCourseAverage(int courseClassId, int studentId, int semester);
    }
}