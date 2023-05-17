using SchoolManagementApp.Domain.Models;
using SchoolManagementApp.Domain.RepositoriesAbstractions;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace SchoolManagementApp.DataAccess.Repositories
{
    internal class TeacherRepository : RepositoryBase<Teacher>, ITeacherRepository
    {
        public TeacherRepository(SchoolManagementDbContext dbcontext) : base(dbcontext)
        {
        }

        public new IEnumerable<Teacher> GetAll()
        {
            var teachers = GetRecords()
                .Include(c => c.User)
                .Include(c => c.User.Person)
                .ToList();

            return teachers;
        }
    }
}
