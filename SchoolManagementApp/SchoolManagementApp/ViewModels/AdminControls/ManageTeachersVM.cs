using SchoolManagementApp.Commands;
using SchoolManagementApp.DataAccess.Models;
using SchoolManagementApp.Services.RepositoryServices.Abstractions;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using To_Do_List_Management_App.ViewModels;

namespace SchoolManagementApp.ViewModels.AdminControls
{
    public class ManageTeachersVM : BaseVM
    {
        private readonly ITeacherService _teacherService;

        public ManageTeachersVM(ITeacherService teacherService)
        {
            _teacherService = teacherService ?? throw new ArgumentNullException(nameof(teacherService));

            TeacherList = _teacherService.GetAll();
        }

        public ObservableCollection<Teacher> TeacherList
        {
            get => _teacherService.TeacherList;
            set => _teacherService.TeacherList = value;
        }

        private Teacher selectedTeacher;
        public Teacher SelectedTeacher
        {
            get { return selectedTeacher; }
            set
            {
                selectedTeacher = value;
                OnPropertyChanged(nameof(SelectedTeacher));
            }
        }

        private ICommand addCommand;
        public ICommand AddCommand
        {
            get
            {
                if (addCommand == null)
                {
                    addCommand = new RelayCommands<Teacher>(_teacherService.Add, param => selectedTeacher == null);
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
                    updateCommand = new RelayCommands<Teacher>(_teacherService.Edit, param => selectedTeacher == null);
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
                    deleteCommand = new RelayCommands<Teacher>(_teacherService.Remove, param => selectedTeacher == null);
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
                    clearCommand = new RelayCommand(Clear, param => selectedTeacher != null);
                }
                return clearCommand;
            }
        }

        private void Clear()
        {
            SelectedTeacher = null;
        }
    }
}
