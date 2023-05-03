﻿using SchoolManagementApp.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace SchoolManagementApp.DataAccess.Repositories
{
    internal class CourseRepository
    {
        private readonly SchoolManagementDbContext _dbContext;

        public CourseRepository(SchoolManagementDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public IEnumerable<CourseType> GetAll()
        {
            return _dbContext.Courses.ToList();
        }

        public CourseType GetById(int id)
        {
            var roleFromDb = _dbContext.Courses.FirstOrDefault(role => role.Id == id);

            if (roleFromDb == null)
            {
                throw new ArgumentNullException($"The role with Id: {id} was not found");
            }

            return roleFromDb;
        }

        public void Add(CourseType courseType)
        {
            if (courseType == null)
            {
                throw new ArgumentNullException(nameof(courseType));
            }
            if (_dbContext.Courses.Any(x => x.Course == courseType.Course))
            {
                throw new ArgumentException($"The role with name: {courseType.Course} already exists");
            }
            _dbContext.Courses.Add(courseType);
            _dbContext.SaveChanges();
        }

        public void Update(CourseType courseType)
        {
            if (courseType == null)
            {
                throw new ArgumentNullException(nameof(courseType));
            }

            var existingEntity = GetById(courseType.Id);
            if (existingEntity == null)
            {
                throw new ArgumentNullException(nameof(existingEntity));
            }

            _dbContext.Courses.AddOrUpdate(courseType);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = GetById(id);
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _dbContext.Courses.Remove(entity);
            _dbContext.SaveChanges();
        }
    }
}