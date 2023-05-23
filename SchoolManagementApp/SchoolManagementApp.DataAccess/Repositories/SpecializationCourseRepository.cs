using SchoolManagementApp.Domain.Models;
using SchoolManagementApp.Domain.RepositoriesAbstractions;

namespace SchoolManagementApp.DataAccess.Repositories
{
    public class SpecializationCourseRepository : RepositoryBase<SpecializationCourse>, ISpecializationCourseRepository
    {
        public SpecializationCourseRepository(SchoolManagementDbContext dbContext) : base(dbContext)
        {
        }
    }
}
