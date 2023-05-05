using SchoolManagementApp.DataAccess.Abstractions;
using SchoolManagementApp.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace SchoolManagementApp.DataAccess.Repositories
{
    internal class StudentRepository : IStudentRepository
    {
        public readonly SchoolManagementDbContext _dbContext;

        public StudentRepository(SchoolManagementDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public void Add(Student entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _dbContext.Students.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(int entityId)
        {
            var entity = GetById(entityId);
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _dbContext.Students.Remove(entity);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Student> GetAll()
        {
            return _dbContext.Students.ToList();
        }

        public Student GetById(int entityId)
        {
            var studentFromDb = _dbContext.Students.FirstOrDefault(role => role.Id == entityId);

            if (studentFromDb == null)
            {
                throw new ArgumentNullException($"The role with Id: {entityId} was not found");
            }

            return studentFromDb;
        }

        public Student GetByUserId(int userId)
        {
            throw new NotImplementedException();
        }

        public void Update(Student entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            var existingEntity = GetById(entity.Id);
            if (existingEntity == null)
            {
                throw new ArgumentNullException(nameof(existingEntity));
            }

            _dbContext.Students.AddOrUpdate(entity);
            _dbContext.SaveChanges();
        }
    }
}
