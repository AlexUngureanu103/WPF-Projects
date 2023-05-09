using SchoolManagementApp.DataAccess.Abstractions;
using SchoolManagementApp.DataAccess.Models;

namespace SchoolManagementApp.DataAccess.Repositories
{
    internal class PersonRepository : RepositoryBase<Person>, IPersonRepository
    {
        public PersonRepository(SchoolManagementDbContext context) : base(context)
        {
        }
    }
}
