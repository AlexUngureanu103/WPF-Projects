using SchoolManagementApp.Domain.Models;
using SchoolManagementApp.Domain.Models.StudentRelated;
using SchoolManagementApp.Domain.ServiceAbstractions;
using SchoolManagementApp.Services.Application;
using System;
using To_Do_List_Management_App.ViewModels;

namespace SchoolManagementApp.ViewModels
{
    public class TeacherUserControlVM : BaseVM
    {
        public readonly Teacher teacher;

        private readonly IClassService _classService;

        private readonly ITeacherService _teacherService;

        public Class ownClass { get; }

        public TeacherUserControlVM(LoggedUser loggedUser, IClassService classService, ITeacherService teacherService)
        {
            if (loggedUser == null) throw new ArgumentNullException(nameof(loggedUser));
            _classService = classService ?? throw new ArgumentNullException(nameof(classService));
            _teacherService = teacherService ?? throw new ArgumentNullException(nameof(teacherService));

            teacher = _teacherService.GetTeacherById(loggedUser.User.Id);
            ownClass = _classService.GetClassByClassMasterId(teacher);
            
            IsClassMaster = (ownClass != null);
        }

        private bool isClassMaster;
        public bool IsClassMaster
        {
            get => isClassMaster;
            set
            {
                isClassMaster = value;
                OnPropertyChanged(nameof(IsClassMaster));
            }
        }
    }
}
