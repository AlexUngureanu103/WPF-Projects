using SchoolManagementApp.DataAccess.Models;

namespace SchoolManagementApp.DataAccess.Abstractions
{
    internal interface IRoleRepository : IRepository<Role>
    {
        Role GetByRole(string role);
    }
}
