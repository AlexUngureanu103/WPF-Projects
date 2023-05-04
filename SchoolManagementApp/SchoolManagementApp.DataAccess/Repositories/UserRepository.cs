using SchoolManagementApp.DataAccess.Abstractions;
using SchoolManagementApp.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace SchoolManagementApp.DataAccess.Repositories
{
    internal class UserRepository : IUserRepository
    {
        private readonly SchoolManagementDbContext _dbContext;

        public UserRepository(SchoolManagementDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public void Add(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            if (_dbContext.Users.Any(x => x.Email == user.Email))
            {
                throw new ArgumentException($"The user with Email: {user.Email} already exists");
            }
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = GetById(id);
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _dbContext.Users.Remove(entity);
            _dbContext.SaveChanges();
        }

        public IEnumerable<User> GetAll()
        {
            return _dbContext.Users.ToList();
        }

        public User GetById(int id)
        {
            var roleFromDb = _dbContext.Users.FirstOrDefault(user => user.Id == id);

            if (roleFromDb == null)
            {
                throw new ArgumentNullException($"The user with Id: {id} was not found");
            }

            return roleFromDb;
        }

        public void Update(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            var existingEntity = GetById(user.Id);
            if (existingEntity == null)
            {
                throw new ArgumentNullException(nameof(existingEntity));
            }

            _dbContext.Users.AddOrUpdate(user);
            _dbContext.SaveChanges();
        }
    }
}
