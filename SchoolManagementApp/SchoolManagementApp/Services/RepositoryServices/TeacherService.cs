using SchoolManagementApp.DataAccess;
using SchoolManagementApp.DataAccess.Models;
using SchoolManagementApp.Services.RepositoryServices.Abstractions;
using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace SchoolManagementApp.Services.RepositoryServices
{
    internal class TeacherService : ITeacherService
    {
        private readonly UnitOfWork unitOfWork;

        public ObservableCollection<Teacher> TeacherList { get; set; }

        private string errorMessage;

        public TeacherService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        private bool ValidateTeacher(Teacher teacher)
        {
            var alreadyExists = unitOfWork.Teachers.Any(c => c.UserId == teacher.UserId && c.Id != teacher.Id);
            if (alreadyExists)
            {
                errorMessage = "Teacher with this user id already exists";
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
                return;

            unitOfWork.Teachers.Add(entity);
            TeacherList.Add(entity);
            unitOfWork.SaveChanges();
        }

        public void Edit(Teacher entity)
        {
            Teacher teacherFromDb = unitOfWork.Teachers.GetById(entity.Id);
            if (teacherFromDb == null)
            {
                errorMessage = "Teacher not found";
                return;
            }

            if (!ValidateTeacher(entity))
                return;

            //unitOfWork.Teachers.Update(entity);
            teacherFromDb.UserId = entity.UserId;

            unitOfWork.SaveChanges();
        }

        public void Remove(Teacher entity)
        {
            if (entity == null)
            {
                errorMessage = "Teacher cannot be null";
                return;
            }

            var result = MessageBox.Show($"Are u sure u want to delete the teacher with {entity.Id}?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.No) return;

            unitOfWork.Teachers.Remove(entity);
            TeacherList.Remove(entity);
            unitOfWork.SaveChanges();
        }
    }
}
