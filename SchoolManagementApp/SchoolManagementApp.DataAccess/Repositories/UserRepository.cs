using SchoolManagementApp.Domain.Models;
using SchoolManagementApp.Domain.RepositoriesAbstractions;
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
            return GetRecords().FirstOrDefault(user => user.Email == email);
        }
    }
}
