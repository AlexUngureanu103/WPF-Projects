using SchoolManagementApp.Domain.Models.StudentRelated;
using SchoolManagementApp.Domain.RepositoriesAbstractions;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace SchoolManagementApp.DataAccess.Repositories
{
    public class ClassRepository : RepositoryBase<Class>, IClassRepository
    {
        public ClassRepository(SchoolManagementDbContext dbContext) : base(dbContext)
        {
        }

        public new IEnumerable<Class> GetAll()
        {
            var classes = GetRecords()
                .Include(c => c.Teacher)
                .Include(c => c.Teacher.User)
                .Include(c => c.Teacher.User.Person)
                .Include(c => c.Specialization);

            return classes;
        }

        public Class GetClassByClassMasterId(int classMasterId)
        {
            var ownClass = GetAll().FirstOrDefault(c => c.TeacherId == classMasterId);

            return ownClass;
        }
    }
}
