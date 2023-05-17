using SchoolManagementApp.Domain.Models;
using SchoolManagementApp.Domain.RepositoriesAbstractions;

namespace SchoolManagementApp.DataAccess.Repositories
{
    public class PersonRepository : RepositoryBase<Person>, IPersonRepository
    {
        public PersonRepository(SchoolManagementDbContext context) : base(context)
        {
        }
    }
}
