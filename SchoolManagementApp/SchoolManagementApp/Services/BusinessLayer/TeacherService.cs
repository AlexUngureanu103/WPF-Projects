using SchoolManagementApp.DataAccess;
using SchoolManagementApp.Domain.Models;
using SchoolManagementApp.Domain.ServiceAbstractions;
using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace SchoolManagementApp.Services.BusinessLayer
{
    internal class TeacherService : ITeacherService
    {
        private readonly UnitOfWork unitOfWork;

        public ObservableCollection<Teacher> TeacherList { get; set; }

        public string errorMessage { get; set; }

        private readonly log4net.ILog log;

        public TeacherService(UnitOfWork unitOfWork, log4net.ILog log)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            this.log = log ?? throw new ArgumentNullException(nameof(log));
        }

        public Teacher GetTeacherById(int userId)
        {
            var teacher = unitOfWork.Teachers.GetTeacherByUserId(userId);

            return teacher;
        }


        private bool ValidateTeacher(Teacher teacher)
        {
            var alreadyExists = unitOfWork.Teachers.Any(c => c.UserId == teacher.UserId && c.Id != teacher.Id);
            if (alreadyExists)
            {
                errorMessage = $"Teacher with this user id: {teacher.UserId} already exists";
                return false;
            }

            return true;
        }

        public ObservableCollection<Teacher> GetAll()
        {
            return new ObservableCollection<Teacher>(unitOfWork.Teachers.GetAll());
        }

        public void Add(Teacher entity)
        {
            if (!ValidateTeacher(entity))
            {
                log.Error(errorMessage);
                return;
            }

            unitOfWork.Teachers.Add(entity);
            TeacherList.Add(entity);
            unitOfWork.SaveChanges();
            log.Info($"Teacher with id {entity.Id} added");
            errorMessage = string.Empty;
        }

        public void Edit(Teacher entity)
        {
            Teacher teacherFromDb = unitOfWork.Teachers.GetById(entity.Id);
            if (teacherFromDb == null)
            {
                errorMessage = "Teacher not found";
                log.Error(errorMessage);
                return;
            }

            if (!ValidateTeacher(entity))
            {
                log.Error(errorMessage);
                return;
            }

            //unitOfWork.Teachers.Update(entity);
            teacherFromDb.UserId = entity.UserId;

            unitOfWork.SaveChanges();
            log.Info($"Teacher with id {entity.Id} edited");
            errorMessage = string.Empty;
        }

        public void Remove(Teacher entity)
        {
            if (entity == null)
            {
                errorMessage = "Teacher cannot be null";
                log.Error(errorMessage);
                return;
            }

            var result = MessageBox.Show($"Are u sure u want to delete the teacher with {entity.Id}?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.No) return;

            unitOfWork.Teachers.Remove(entity);
            TeacherList.Remove(entity);
            unitOfWork.SaveChanges();
            log.Info($"Teacher with id {entity.Id} removed");
            errorMessage = string.Empty;
        }
    }
}
