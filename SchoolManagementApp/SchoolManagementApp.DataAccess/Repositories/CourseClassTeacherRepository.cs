using SchoolManagementApp.DataAccess.Abstractions;
using SchoolManagementApp.DataAccess.Models;

namespace SchoolManagementApp.DataAccess.Repositories
{
    internal class CourseClassTeacherRepository : RepositoryBase<CourseClassTeacher>, ICourseClassTeacherRepository
    {
        public CourseClassTeacherRepository(SchoolManagementDbContext dbcontext) : base(dbcontext)
        {
        }
    }
}
