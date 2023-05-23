using SchoolManagementApp.Domain.Models;
using SchoolManagementApp.Domain.RepositoriesAbstractions;
using System.Collections.Generic;
using System.Data.Entity;

namespace SchoolManagementApp.DataAccess.Repositories
{
    internal class CourseClassTeacherRepository : RepositoryBase<CourseClassTeacher>, ICourseClassTeacherRepository
    {
        public CourseClassTeacherRepository(SchoolManagementDbContext dbcontext) : base(dbcontext)
        {
        }

        public new IEnumerable<CourseClassTeacher> GetAll()
        {
            var courseClassTeacher = GetRecords()
                .Include(c => c.CourseClass)
                .Include(c => c.CourseClass.CourseType)
                .Include(c => c.CourseClass.Class)
                .Include(c => c.CourseClass.Class.Specialization)
                .Include(c => c.Teacher)
                .Include(c => c.Teacher.User)
                .Include(c => c.Teacher.User.Person);

            return courseClassTeacher;
        }
    }
}
