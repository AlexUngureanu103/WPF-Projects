using SchoolManagementApp.DataAccess.Abstractions;
using SchoolManagementApp.DataAccess.Models.StudentRelated;
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
    }
}
