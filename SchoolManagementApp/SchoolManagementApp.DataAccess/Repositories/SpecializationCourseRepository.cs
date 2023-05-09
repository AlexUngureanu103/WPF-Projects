using SchoolManagementApp.DataAccess.Abstractions;
using SchoolManagementApp.DataAccess.Models;

namespace SchoolManagementApp.DataAccess.Repositories
{
    public class SpecializationCourseRepository : RepositoryBase<SpecializationCourse>, ISpecializationCourseRepository
    {
        public SpecializationCourseRepository(SchoolManagementDbContext dbContext) : base(dbContext)
        {
        }
    }
}
