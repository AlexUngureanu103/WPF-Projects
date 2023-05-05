using SchoolManagementApp.DataAccess.Abstractions;
using SchoolManagementApp.DataAccess.Models;
using System.Linq;

namespace SchoolManagementApp.DataAccess.Repositories
{
    internal class UserRepository : RepositoryBase<User>, IUserRepository
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
