using SchoolManagementApp.DataAccess.Abstractions;
using SchoolManagementApp.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace SchoolManagementApp.DataAccess.Repositories
{
    internal class RoleRepository : IRoleRepository
    {
        private readonly SchoolManagementDbContext _dbContext;

        public RoleRepository(SchoolManagementDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public IEnumerable<Role> GetAll()
        {
            return _dbContext.Roles.ToList();
        }

        public Role GetById(int id)
        {
            var roleFromDb = _dbContext.Roles.FirstOrDefault(role => role.Id == id);

            if (roleFromDb == null)
            {
                throw new ArgumentNullException($"The role with Id: {id} was not found");
            }

            return roleFromDb;
        }

        public void Add(Role role)
        {
            if (role == null)
            {
                throw new ArgumentNullException(nameof(role));
            }
            if (_dbContext.Roles.Any(x => x.AssignedRole == role.AssignedRole))
            {
                throw new ArgumentException($"The role with name: {role.AssignedRole} already exists");
            }
            _dbContext.Roles.Add(role);
            _dbContext.SaveChanges();
        }

        public void Update(Role role)
        {
            if (role == null)
            {
                throw new ArgumentNullException(nameof(role));
            }

            var existingEntity = GetById(role.Id);
            if (existingEntity == null)
            {
                throw new ArgumentNullException(nameof(existingEntity));
            }

            _dbContext.Roles.AddOrUpdate(role);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = GetById(id);
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _dbContext.Roles.Remove(entity);
            _dbContext.SaveChanges();
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
