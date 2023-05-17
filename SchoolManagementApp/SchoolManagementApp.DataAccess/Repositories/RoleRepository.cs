using SchoolManagementApp.Domain.Models;
using SchoolManagementApp.Domain.RepositoriesAbstractions;
using System;
using System.Linq;

namespace SchoolManagementApp.DataAccess.Repositories
{
    public class RoleRepository : RepositoryBase<Role>, IRoleRepository
    {
        public RoleRepository(SchoolManagementDbContext dbContext) : base(dbContext)
        {
        }

        public Role GetByRole(string assignedRole)
        {
            var roleFromDb = _dbContext.Roles.FirstOrDefault(role => role.AssignedRole == assignedRole);

            if (roleFromDb == null)
            {
                throw new ArgumentNullException($"The role with name: {assignedRole} was not found");
            }

            return roleFromDb;
        }
    }
}
