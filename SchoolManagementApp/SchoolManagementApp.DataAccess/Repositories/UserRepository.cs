using SchoolManagementApp.Domain.Models;
using SchoolManagementApp.Domain.RepositoriesAbstractions;
using System.Data.Entity;
using System.Linq;

namespace SchoolManagementApp.DataAccess.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(SchoolManagementDbContext dbContext) : base(dbContext)
        {
        }

        public User GetByEmail(string email)
        {
            return GetRecords()
                .Include(c=>c.Person)
                .FirstOrDefault(user => user.Email == email);
        }
    }
}
