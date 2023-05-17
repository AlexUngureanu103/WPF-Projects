using SchoolManagementApp.Domain.Models;

namespace SchoolManagementApp.Domain.RepositoriesAbstractions
{
    public interface IRoleRepository : IRepository<Role>
    {
        Role GetByRole(string role);
    }
}
