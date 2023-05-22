using SchoolManagementApp.Commands;
using SchoolManagementApp.Domain.Models;
using SchoolManagementApp.Domain.Models.StudentRelated;
using SchoolManagementApp.Domain.ServiceAbstractions;
using SchoolManagementApp.Services.ApplicationLayer;
using System;
using System.Windows;
using System.Windows.Input;
using To_Do_List_Management_App.ViewModels;

namespace SchoolManagementApp.ViewModels
{
    public class ClassMasterUserControlVM : BaseVM
    {
        private readonly Teacher teacher;

        private readonly Class ownClass;

        private readonly ITeacherService _teacherService;

        private readonly IClassService _classService;

        public ClassMasterUserControlVM(ITeacherService teacherService, IClassService classService, LoggedUser loggedUser)
        {
            if (loggedUser == null)
                throw new ArgumentNullException(nameof(loggedUser));
            _teacherService = teacherService ?? throw new ArgumentNullException(nameof(teacherService));
            _classService = classService ?? throw new ArgumentNullException(nameof(classService));

            teacher = _teacherService.GetTeacherById(loggedUser.User.Id);
            ownClass = _classService.GetClassByClassMasterId(teacher);
        }


        private ICommand classMasterInfoCommand;
        public ICommand ClassMasterInfoCommand
        {
            get
            {
                if (classMasterInfoCommand == null)
                {
                    classMasterInfoCommand = new RelayCommand(DisplayInfo);
                }
                return classMasterInfoCommand;
            }
        }

        private void DisplayInfo()
        {
            MessageBox.Show($"Email: {teacher.User.Email}\nName: {teacher.User.Person.FirstName} {teacher.User.Person.LastName}\nClass: {ownClass.Name}\n Specialization: {ownClass.Specialization.Name}", "Info");
        }
    }
}
