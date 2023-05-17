using SchoolManagementApp.Domain.Models;
using SchoolManagementApp.Domain.RepositoriesAbstractions;

namespace SchoolManagementApp.DataAccess.Repositories
{
    internal class CourseClassTeacherRepository : RepositoryBase<CourseClassTeacher>, ICourseClassTeacherRepository
    {
        public CourseClassTeacherRepository(SchoolManagementDbContext dbcontext) : base(dbcontext)
        {
        }
    }
}
