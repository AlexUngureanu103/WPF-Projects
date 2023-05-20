using SchoolManagementApp.Commands;
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
    public class ManageGradesVM : BaseVM
    {
        private readonly IClassService _classService;

        private readonly IStudentService _studentService;

        private readonly IGradeService _gradeService;

        private readonly ICourseService _courseService;

        public ManageGradesVM(IClassService classService, IStudentService studentService, IGradeService gradeService, ICourseService courseService)
        {
            this._studentService = studentService ?? throw new ArgumentNullException(nameof(studentService));
            this._classService = classService ?? throw new ArgumentNullException(nameof(classService));
            this._gradeService = gradeService ?? throw new ArgumentNullException(nameof(gradeService));
            this._courseService = courseService ?? throw new ArgumentNullException(nameof(courseService));

            StudentList = _studentService.GetAll();
            GradeList = _gradeService.GetAll();
            ClassList = _classService.GetAll();
            CourseList = _courseService.GetAll();
            Semesters = new List<int> { 1, 2 };
            GradeValues = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        }

        public ObservableCollection<Class> ClassList
        {
            get => _classService.ClassList;
            set => _classService.ClassList = value;
        }

        public ObservableCollection<Grade> GradeList
        {
            get => _gradeService.GradeList;
            set => _gradeService.GradeList = value;
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

        private Grade selectedGrade;
        public Grade SelectedGrade
        {
            get { return selectedGrade; }
            set
            {
                selectedGrade = value;
                OnPropertyChanged(nameof(SelectedGrade));
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
                GradeList = _gradeService.GetStudentGrades(selectedStudent);
                if (selectedStudent == null)
                    CourseList = _courseService.GetAll();
                else
                    CourseList = _courseService.GetClassCourses((int)selectedStudent.ClassId);
                OnPropertyChanged(nameof(CourseList));
                OnPropertyChanged(nameof(GradeList));
            }
        }

        private List<int> gradeValues;
        public List<int> GradeValues
        {
            get
            {
                return gradeValues;
            }
            set
            {
                gradeValues = value;
                OnPropertyChanged(nameof(GradeValues));
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

        private ICommand addCommand;
        public ICommand AddCommand
        {
            get
            {
                if (addCommand == null)
                {
                    addCommand = new RelayCommands<Grade>(_gradeService.Add, param => selectedGrade == null);
                }
                return addCommand;
            }
        }

        private ICommand updateCommand;
        public ICommand UpdateCommand
        {
            get
            {
                if (updateCommand == null)
                {
                    updateCommand = new RelayCommands<Grade>(_gradeService.Edit, param => selectedGrade != null);
                }
                return updateCommand;
            }
        }

        private ICommand deleteCommand;
        public ICommand DeleteCommand
        {
            get
            {
                if (deleteCommand == null)
                {
                    deleteCommand = new RelayCommands<Grade>(_gradeService.Remove, param => selectedGrade != null);
                }
                return deleteCommand;
            }
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
            SelectedGrade = null;
            GradeList = _gradeService.GetAll();
            OnPropertyChanged(nameof(GradeList));
        }
    }
}
