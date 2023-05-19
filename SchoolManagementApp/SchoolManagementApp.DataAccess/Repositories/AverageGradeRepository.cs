using SchoolManagementApp.Domain.Models.StudentRelated;
using SchoolManagementApp.Domain.RepositoriesAbstractions;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace SchoolManagementApp.DataAccess.Repositories
{
    internal class AverageGradeRepository : RepositoryBase<AverageGrade>, IAverageGradeRepository
    {
        public AverageGradeRepository(SchoolManagementDbContext context) : base(context)
        {
        }

        public new IEnumerable<AverageGrade> GetAll()
        {
            var AverageGrades = GetRecords()
                .Include(c => c.Student)
                .Include(c => c.Student.User)
                .Include(c => c.Student.User.Person)
                .Include(c => c.ClassCourse)
                .Include(c => c.ClassCourse.Class)
                .Include(c => c.ClassCourse.Class.Specialization)
                .Include(c => c.ClassCourse.CourseType);

            return AverageGrades;
        }

        public IEnumerable<AverageGrade> GetClassAverageGrades(int classId)
        {
            var AverageClassGrades = GetAll()
                .Where(c => c.ClassCourse.ClassId == classId);

            return AverageClassGrades;
        }

        public IEnumerable<AverageGrade> GetStudentAverageGrades(int studentId)
        {
            var AverageStudentGrades = GetAll()
                .Where(c => c.StudentId == studentId);

            return AverageStudentGrades;
        }

        public AverageGrade GetStudentCourseAverage(int courseClassId, int studentId, int semester)
        {
            var AverageStudentCourseGrade = GetAll()
                .Where(c => c.StudentId == studentId && c.CourseClasstId == courseClassId && c.Semester == semester)
                .FirstOrDefault();

            return AverageStudentCourseGrade;
        }
    }
}
