﻿using SchoolManagementApp.DataAccess;
using SchoolManagementApp.Domain.Models;
using SchoolManagementApp.Domain.Models.StudentRelated;
using SchoolManagementApp.Domain.ServiceAbstractions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace SchoolManagementApp.Services.BusinessLayer
{
    internal class StudentService : IStudentService
    {
        private readonly UnitOfWork unitOfWork;

        public ObservableCollection<Student> StudentList { get; set; }

        public string errorMessage { get; set; }

        private readonly log4net.ILog log;

        public StudentService(UnitOfWork unitOfWork, log4net.ILog log)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            this.log = log ?? throw new ArgumentNullException(nameof(log));
        }

        public ObservableCollection<Student> GetAll()
        {
            var students = new ObservableCollection<Student>(unitOfWork.Students.GetAll());
            return students;
        }

        public ObservableCollection<Student> GetStudentsByClassId(int classId)
        {
            var students = unitOfWork.Students.GetStudentByClassId(classId);
            //foreach (Student student in students)
            //{
            //    student.Grades = new List<Grade>(unitOfWork.Grades.GetStudentGrades(student.Id));
            //}

            return new ObservableCollection<Student>(students);
        }

        private bool ValidateStudent(Student student)
        {
            if (student == null)
            {
                errorMessage = "Student cannot be null";
                return false;
            }

            var validClass = unitOfWork.Classes.GetById((int)student.ClassId);
            if (validClass == null)
            {
                errorMessage = $"Class: {student.ClassId} not found";
                return false;
            }

            var validUser = unitOfWork.Users.GetById((int)student.UserId);
            if (validUser == null)
            {
                errorMessage = $"User: {student.UserId} not found";
                return false;
            }

            if (student.UserId != null)
            {
                if (StudentList.Any(c => c.UserId == student.UserId && c.Id != student.Id))
                {
                    errorMessage = $"User id: {student.UserId} is already linked to another user";
                    return false;
                }
            }
            return true;
        }

        public void Add(Student student)
        {
            if (!ValidateStudent(student))
            {
                log.Error(errorMessage);
                return;
            }

            student.Grades = new List<Grade>();

            unitOfWork.Students.Add(student);
            StudentList.Add(student);
            unitOfWork.SaveChanges();
            log.Info($"Student with id: {student.Id} was added");
            errorMessage = string.Empty;
        }

        public void Edit(Student student)
        {
            Student StudentFromDb = unitOfWork.Students.GetById(student.Id);

            if (StudentFromDb == null)
            {
                errorMessage = "Student not found";
                log.Error(errorMessage);
                return;
            }

            if (!ValidateStudent(student))
            {
                log.Error(errorMessage);
                return;
            }

            //unitOfWork.Students.Update(student);
            StudentFromDb.UserId = student.UserId;
            StudentFromDb.ClassId = student.ClassId;

            unitOfWork.SaveChanges();
            log.Info($"Student with id: {student.Id} was edited");
            errorMessage = string.Empty;
        }

        public void Remove(Student student)
        {
            if (student == null)
            {
                errorMessage = "Student cannot be null";
                log.Error(errorMessage);
                return;
            }

            var result = MessageBox.Show($"Are u sure u want to delete the student with {student.Id}?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.No) return;

            unitOfWork.Students.Remove(student);
            StudentList.Remove(student);
            unitOfWork.SaveChanges();
            log.Info($"Student with id: {student.Id} was removed");
            errorMessage = string.Empty;
        }

        public Student GetStudentByUserId(User user)
        {
            if (user == null)
            {
                errorMessage = "User cannot be null";
                log.Error(errorMessage);
                return null;
            }
            var student = unitOfWork.Students.GetByUserId(user.Id);
            errorMessage = string.Empty;

            return student;
        }
    }
}
