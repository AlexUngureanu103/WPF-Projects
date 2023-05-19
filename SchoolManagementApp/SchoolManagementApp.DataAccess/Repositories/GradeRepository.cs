using SchoolManagementApp.Domain.Models.StudentRelated;
using SchoolManagementApp.Domain.RepositoriesAbstractions;
using System.Collections.Generic;
using System.Linq;

namespace SchoolManagementApp.DataAccess.Repositories
{
    public class GradeRepository : RepositoryBase<Grade>, IGradeRepository
    {
        public GradeRepository(SchoolManagementDbContext context) : base(context)
        {

        }

        public IEnumerable<Grade> GetStudentGrades(int studentId)
        {
            return GetRecords().Where(grade => grade.StudentId == studentId);
        }

        public IEnumerable<Grade> GetStudentGrades(int studentId, int courseId)
        {
            return GetRecords().Where(grade => grade.StudentId == studentId && grade.CourseTypeId == courseId);
        }
    }
}
