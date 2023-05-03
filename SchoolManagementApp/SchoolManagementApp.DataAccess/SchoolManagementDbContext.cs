using SchoolManagementApp.DataAccess.Models;
using System.Data.Entity;

namespace SchoolManagementApp.DataAccess
{
    internal class SchoolManagementDbContext : DbContext
    {
        public SchoolManagementDbContext(string connectionString) : base(connectionString)
        {
        }

        public DbSet<Role> Roles { get; set; }
    }
}
