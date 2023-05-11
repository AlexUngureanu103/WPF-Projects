using SchoolManagementApp.DataAccess.Abstractions;
using SchoolManagementApp.DataAccess.Models;

namespace SchoolManagementApp.DataAccess.Repositories
{
    internal class TeacherRepository : RepositoryBase<Teacher>, ITeacherRepository
    {
        public TeacherRepository(SchoolManagementDbContext dbcontext) : base(dbcontext)
        {
        }
    }
}
