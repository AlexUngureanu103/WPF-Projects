using SchoolManagementApp.DataAccess.Models;
using System.Collections.Generic;

namespace SchoolManagementApp.DataAccess.Abstractions
{
    internal interface IRoleRepository
    {
        IEnumerable<Role> GetAll();

        Role GetById(int id);

        void Add(Role role);

        void Update(Role role);

        void Delete(int id);
    }
}
