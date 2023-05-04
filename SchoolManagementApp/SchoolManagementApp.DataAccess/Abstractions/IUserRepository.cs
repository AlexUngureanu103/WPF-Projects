using SchoolManagementApp.DataAccess.Models;

namespace SchoolManagementApp.DataAccess.Abstractions
{
    internal interface IUserRepository : IRepository<User>
    {
        User GetByEmail(string email);
    }
}
