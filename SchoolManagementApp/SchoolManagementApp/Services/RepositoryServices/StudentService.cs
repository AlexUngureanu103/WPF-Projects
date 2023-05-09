using SchoolManagementApp.DataAccess;
using SchoolManagementApp.DataAccess.Models;
using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace SchoolManagementApp.Services.RepositoryServices
{
    internal class StudentService : ICollectionService<Student>
    {
        private readonly UnitOfWork unitOfWork;

        public ObservableCollection<Student> StudentList { get; set; }

        private string errorMessage;

        public StudentService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public ObservableCollection<Student> GetAll()
        {
            return new ObservableCollection<Student>(unitOfWork.Students.GetAll());
        }
        private bool ValidateStudent(Student student)
        {
            if (student == null /*|| string.IsNullOrEmpty(student.FirstName) || string.IsNullOrEmpty(student.LastName) || string.IsNullOrEmpty(student.Address)*/)
            {
                errorMessage = "Student cannot be null";
                return false;
            }

            var validClass = unitOfWork.Classes.GetById(student.ClassId);
            if (validClass == null)
            {
                errorMessage = "Class not found";
                return false;
            }

            var validUser = unitOfWork.Users.GetById(student.UserId);
            if (validUser == null)
            {
                errorMessage = "User not found";
                return false;
            }
            return true;
        }

        public void Add(Student student)
        {
            if (!ValidateStudent(student))
                return;

            unitOfWork.Students.Add(student);
            StudentList.Add(student);
            unitOfWork.SaveChanges();
        }

        public void Edit(Student student)
        {
            Student Student = unitOfWork.Students.GetById(student.Id);

            if (Student == null)
            {
                errorMessage = "Student not found";
                return;
            }

            if (!ValidateStudent(student))
                return;

            unitOfWork.Students.Update(student);
            unitOfWork.SaveChanges();
        }

        public void Remove(Student student)
        {
            var result = MessageBox.Show($"Are u sure u want to delete the student with {student.Id}?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.No) return;
            if (student == null)
            {
                errorMessage = "Student cannot be null";
                return;
            }

            unitOfWork.Students.Remove(student);
            unitOfWork.SaveChanges();
        }
    }
}
