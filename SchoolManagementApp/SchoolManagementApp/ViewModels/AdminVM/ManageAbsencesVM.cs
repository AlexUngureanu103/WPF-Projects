﻿using SchoolManagementApp.Commands;
using SchoolManagementApp.Domain.Models;
using SchoolManagementApp.Domain.Models.StudentRelated;
using SchoolManagementApp.Domain.ServiceAbstractions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using To_Do_List_Management_App.ViewModels;

namespace SchoolManagementApp.ViewModels.AdminVM
{
    public class ManageAbsencesVM : BaseVM
    {
        private readonly IClassService _classService;

        private readonly IStudentService _studentService;

        private readonly IAbsencesService _absenceService;

        private readonly ICourseService _courseService;

        public ManageAbsencesVM(IClassService classService, IStudentService studentService, IAbsencesService absenceService, ICourseService courseService)
        {
            this._studentService = studentService ?? throw new ArgumentNullException(nameof(studentService));
            this._classService = classService ?? throw new ArgumentNullException(nameof(classService));
            this._absenceService = absenceService ?? throw new ArgumentNullException(nameof(absenceService));
            this._courseService = courseService ?? throw new ArgumentNullException(nameof(courseService));

            StudentList = _studentService.GetAll();
            AbsenceList = _absenceService.GetAll();
            ClassList = _classService.GetAll();
            CourseList = _courseService.GetAll();
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

        public ObservableCollection<Class> ClassList
        {
            get => _classService.ClassList;
            set => _classService.ClassList = value;
        }

        public ObservableCollection<Absences> AbsenceList
        {
            get => _absenceService.AbsenceList;
            set => _absenceService.AbsenceList = value;
        }

        public ObservableCollection<Student> StudentList
        {
            get => _studentService.StudentList;
            set => _studentService.StudentList = value;
        }

        public ObservableCollection<CourseType> CourseList
        {
            get => _courseService.CourseList;
            set => _courseService.CourseList = value;
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

        private Absences selectedAbsence;
        public Absences SelectedAbsence
        {
            get { return selectedAbsence; }
            set
            {
                selectedAbsence = value;
                OnPropertyChanged(nameof(SelectedAbsence));
            }
        }

        private Student selectedStudent;
        public Student SelectedStudent
        {
            get { return selectedStudent; }
            set
            {
                selectedStudent = value;
                OnPropertyChanged(nameof(SelectedStudent));
                AbsenceList = _absenceService.GetStudentAbsences(selectedStudent);
                if (selectedStudent == null)
                    CourseList = _courseService.GetAll();
                else
                    CourseList = _courseService.GetClassCourses((int)selectedStudent.ClassId);
                OnPropertyChanged(nameof(CourseList));
                OnPropertyChanged(nameof(AbsenceList));
            }
        }

        private ICommand addCommand;
        public ICommand AddCommand
        {
            get
            {
                if (addCommand == null)
                {
                    addCommand = new RelayCommands<Absences>(Add, param => selectedAbsence == null);
                }
                return addCommand;
            }
        }

        private void Add(Absences absences)
        {
            _absenceService.Add(absences);
            ErrorMessage = _absenceService.errorMessage;
        }

        private ICommand updateCommand;
        public ICommand UpdateCommand
        {
            get
            {
                if (updateCommand == null)
                {
                    updateCommand = new RelayCommands<Absences>(Edit, param => selectedAbsence != null);
                }
                return updateCommand;
            }
        }

        private void Edit(Absences absences)
        {
            _absenceService.Edit(absences);
            ErrorMessage = _absenceService.errorMessage;
        }

        private ICommand deleteCommand;
        public ICommand DeleteCommand
        {
            get
            {
                if (deleteCommand == null)
                {
                    deleteCommand = new RelayCommands<Absences>(Remove, param => selectedAbsence != null);
                }
                return deleteCommand;
            }
        }

        private void Remove(Absences absences)
        {
            _absenceService.Remove(absences);
            ErrorMessage = _absenceService.errorMessage;
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
            SelectedAbsence = null;
            AbsenceList = _absenceService.GetAll();
            OnPropertyChanged(nameof(AbsenceList));
        }
    }
}
