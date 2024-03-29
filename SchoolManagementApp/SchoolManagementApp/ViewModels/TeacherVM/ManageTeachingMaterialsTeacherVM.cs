﻿using SchoolManagementApp.Commands;
using SchoolManagementApp.Domain.Models;
using SchoolManagementApp.Domain.Models.StudentRelated;
using SchoolManagementApp.Domain.ServiceAbstractions;
using SchoolManagementApp.Services.ApplicationLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using To_Do_List_Management_App.ViewModels;

namespace SchoolManagementApp.ViewModels.TeacherVM
{
    public class ManageTeachingMaterialsTeacherVM : BaseVM
    {
        private readonly ITeacherService _teacherService;

        private readonly ICourseService _courseService;

        private readonly ICourseClassTeacherService _courseClassTeacherService;

        private readonly ITeachingMaterialsService _teachingMaterialsService;

        private readonly Teacher teacher;

        public ManageTeachingMaterialsTeacherVM(ITeacherService teacherService, ICourseService courseService, ICourseClassTeacherService courseClassTeacherService, ITeachingMaterialsService teachingMaterialsService, LoggedUser loggedUser)
        {
            _teacherService = teacherService ?? throw new ArgumentNullException(nameof(teacherService));
            _courseService = courseService ?? throw new ArgumentNullException(nameof(courseService));
            _courseClassTeacherService = courseClassTeacherService ?? throw new ArgumentNullException(nameof(courseClassTeacherService));
            _teachingMaterialsService = teachingMaterialsService ?? throw new ArgumentNullException(nameof(teachingMaterialsService));
            if (loggedUser == null)
                throw new ArgumentNullException(nameof(loggedUser));

            teacher = _teacherService.GetTeacherById(loggedUser.User.Id);
            TeachingClassesList = _courseClassTeacherService.GetTeachingClasses(teacher.Id);
            TeachingMaterialsList = new ObservableCollection<TeachingMaterial>();

            Semesters = new List<int> { 1, 2 };
        }

        private string errorMessage;
        public string ErrorMessage
        {
            get => errorMessage;
            set
            {
                errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }

        public ObservableCollection<CourseClassTeacher> TeachingClassesList
        {
            get => _courseClassTeacherService.CourseTeacherList;
            set => _courseClassTeacherService.CourseTeacherList = value;
        }

        private CourseClassTeacher selectedTeachingClass;
        public CourseClassTeacher SelectedTeachingClass
        {
            get => selectedTeachingClass;
            set
            {
                selectedTeachingClass = value;
                OnPropertyChanged(nameof(SelectedTeachingClass));
                if (selectedTeachingClass != null)
                {
                    CourseList = new ObservableCollection<CourseType>{
                        selectedTeachingClass.CourseClass.CourseType
                    };
                    TeachingMaterialsList = _teachingMaterialsService.GetCourseClassTeachingMaterials(selectedTeachingClass.CourseClass);
                }
            }
        }

        public ObservableCollection<CourseType> CourseList
        {
            get => _courseService.CourseList;
            set
            {
                _courseService.CourseList = value;
                OnPropertyChanged(nameof(CourseList));
            }
        }

        private List<int> semesters;
        public List<int> Semesters
        {
            get { return semesters; }
            set
            {
                semesters = value;
                OnPropertyChanged(nameof(Semesters));
            }
        }

        private ObservableCollection<TeachingMaterial> teachingMaterialsList;
        public ObservableCollection<TeachingMaterial> TeachingMaterialsList
        {
            get => _teachingMaterialsService.TeachingMaterialsList;
            set
            {
                _teachingMaterialsService.TeachingMaterialsList = value;
                OnPropertyChanged(nameof(TeachingMaterialsList));
            }
        }

        private TeachingMaterial selectedTeachingMaterial;
        public TeachingMaterial SelectedTeachingMaterial
        {
            get => selectedTeachingMaterial;
            set
            {
                selectedTeachingMaterial = value;
                OnPropertyChanged(nameof(SelectedTeachingMaterial));
            }
        }

        private ICommand addCommand;
        public ICommand AddCommand
        {
            get
            {
                if (addCommand == null)
                {
                    addCommand = new RelayCommands<TeachingMaterial>(Add, param => selectedTeachingMaterial == null);
                }
                return addCommand;
            }
        }

        private void Add(TeachingMaterial teachingMaterial)
        {
            _teachingMaterialsService.Add(teachingMaterial);
            ErrorMessage = _teachingMaterialsService.errorMessage;
        }

        private ICommand updateCommand;
        public ICommand UpdateCommand
        {
            get
            {
                if (updateCommand == null)
                {
                    updateCommand = new RelayCommands<TeachingMaterial>(Edit, param => selectedTeachingMaterial != null);
                }
                return updateCommand;
            }
        }

        private void Edit(TeachingMaterial teachingMaterial)
        {
            _teachingMaterialsService.Edit(teachingMaterial);
            ErrorMessage = _teachingMaterialsService.errorMessage;
        }

        private ICommand deleteCommand;
        public ICommand DeleteCommand
        {
            get
            {
                if (deleteCommand == null)
                {
                    deleteCommand = new RelayCommands<TeachingMaterial>(Remove, param => selectedTeachingMaterial != null);
                }
                return deleteCommand;
            }
        }

        private void Remove(TeachingMaterial teachingMaterial)
        {
            _teachingMaterialsService.Remove(teachingMaterial);
            ErrorMessage = _teachingMaterialsService.errorMessage;
        }

        private ICommand clearCommand;
        public ICommand ClearCommand
        {
            get
            {
                if (clearCommand == null)
                {
                    clearCommand = new RelayCommand(Clear);
                }
                return clearCommand;
            }
        }

        private void Clear()
        {
            ErrorMessage = string.Empty;
            SelectedTeachingClass = null;
            SelectedTeachingMaterial = null;
        }
    }
}
