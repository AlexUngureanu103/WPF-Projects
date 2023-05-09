using SchoolManagementApp.DataAccess.Abstractions;
using SchoolManagementApp.DataAccess.Models;

namespace SchoolManagementApp.DataAccess.Repositories
{
    public class PersonRepository : RepositoryBase<Person>, IPersonRepository
    {
        public PersonRepository(SchoolManagementDbContext context) : base(context)
        {
        }
    }
}
