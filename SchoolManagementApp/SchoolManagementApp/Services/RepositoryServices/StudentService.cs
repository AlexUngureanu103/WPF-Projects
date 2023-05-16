﻿using SchoolManagementApp.DataAccess;
using SchoolManagementApp.DataAccess.Models;
using SchoolManagementApp.DataAccess.Models.StudentRelated;
using SchoolManagementApp.Services.RepositoryServices.Abstractions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace SchoolManagementApp.Services.RepositoryServices
{
    internal class StudentService : IStudentService
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
            var students = new ObservableCollection<Student>(unitOfWork.Students.GetAll().Select(student =>
            {
                student.Grades = new List<Grade>(unitOfWork.Grades.GetStudentGrades(student.Id));
                return student;
            }));
            //students.Select(student =>
            //{
            //    student.Grades.Select(grade =>
            //    {
            //        grade.CourseType = unitOfWork.Courses.GetById((int)grade.CourseTypeId);
            //        return grade;
            //    });
            //    return student;
            //});

            return students;
        }
        private bool ValidateStudent(Student student)
        {
            if (student == null)
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

            if (student.UserId != null)
            {
                if (StudentList.Any(c => c.UserId == student.UserId && c.Id != student.Id))
                {
                    errorMessage = $"User id: {student.UserId} is already linked to naother user";
                    return false;
                }
            }
            return true;
        }

        public void Add(Student student)
        {
            if (!ValidateStudent(student))
                return;

            student.Grades = new List<Grade>();

            unitOfWork.Students.Add(student);
            StudentList.Add(student);
            unitOfWork.SaveChanges();
        }

        public void Edit(Student student)
        {
            Student StudentFromDb = unitOfWork.Students.GetById(student.Id);

            if (StudentFromDb == null)
            {
                errorMessage = "Student not found";
                return;
            }

            if (!ValidateStudent(student))
                return;

            //unitOfWork.Students.Update(student);
            StudentFromDb.UserId = student.UserId;
            StudentFromDb.ClassId = student.ClassId;

            unitOfWork.SaveChanges();
        }

        public void Remove(Student student)
        {
            if (student == null)
            {
                errorMessage = "Student cannot be null";
                return;
            }

            var result = MessageBox.Show($"Are u sure u want to delete the student with {student.Id}?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.No) return;

            unitOfWork.Students.Remove(student);
            StudentList.Remove(student);
            unitOfWork.SaveChanges();
        }
    }
}
