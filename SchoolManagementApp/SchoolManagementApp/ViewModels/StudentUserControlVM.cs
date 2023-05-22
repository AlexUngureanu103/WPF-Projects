using SchoolManagementApp.Commands;
using SchoolManagementApp.Domain.Models;
using SchoolManagementApp.Domain.ServiceAbstractions;
using SchoolManagementApp.Services.ApplicationLayer;
using System;
using System.Windows;
using System.Windows.Input;
using To_Do_List_Management_App.ViewModels;

namespace SchoolManagementApp.ViewModels
{
    public class StudentUserControlVM : BaseVM
    {
        public readonly Student student;

        private readonly IStudentService _studentService;

        public StudentUserControlVM(IStudentService studentService, LoggedUser loggedUser)
        {
            if (loggedUser == null)
                throw new ArgumentNullException(nameof(loggedUser));
            _studentService = studentService ?? throw new ArgumentNullException(nameof(studentService));

            student = _studentService.GetStudentByUserId(loggedUser.User);
        }

        private ICommand studentInfoCommand;
        public ICommand StudentInfoCommand
        {
            get
            {
                if (studentInfoCommand == null)
                {
                    studentInfoCommand = new RelayCommand(DisplayInfo);
                }
                return studentInfoCommand;
            }
        }

        private void DisplayInfo()
        {
            MessageBox.Show($"Email: {student.User.Email}\nName: {student.User.Person.FirstName} {student.User.Person.LastName}\nClass: {student.Class.Name} Specialization: {student.Class.Specialization.Name}", "Info");
        }
    }
}
