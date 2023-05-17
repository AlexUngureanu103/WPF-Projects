using SchoolManagementApp.Domain.Models;

namespace SchoolManagementApp.Domain.RepositoriesAbstractions
{
    public interface IUserRepository : IRepository<User>
    {
        User GetByEmail(string email);
    }
}
