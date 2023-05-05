using SchoolManagementApp.DataAccess.Models;

namespace SchoolManagementApp.DataAccess.Abstractions
{
    public interface IUserRepository : IRepository<User>
    {
        User GetByEmail(string email);
    }
}
