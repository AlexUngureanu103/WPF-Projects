using SchoolManagementApp.DataAccess.Models;

namespace SchoolManagementApp.DataAccess.Abstractions
{
    public interface IRoleRepository : IRepository<Role>
    {
        Role GetByRole(string role);
    }
}
