﻿using SchoolManagementApp.Commands;
using SchoolManagementApp.DataAccess.Abstractions;
using SchoolManagementApp.DataAccess.Models;
using SchoolManagementApp.Services.RepositoryServices.Abstractions;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using To_Do_List_Management_App.ViewModels;

namespace SchoolManagementApp.ViewModels.AdminControls
{
    public class ManageTeachersVM : BaseVM
    {
        private readonly ITeacherService _teacherService;

        private readonly IUserService _userService;

        private readonly IRoleRepository _roleRepository;

        public ManageTeachersVM(ITeacherService teacherService, IUserService userService, IRoleRepository roleRepository)
        {
            _teacherService = teacherService ?? throw new ArgumentNullException(nameof(teacherService));
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _roleRepository = roleRepository ?? throw new ArgumentNullException(nameof(roleRepository));
            TeacherList = _teacherService.GetAll();
            UserList = new ObservableCollection<User>(_userService.GetAll().Where(c => c.RoleId != _roleRepository.GetByRole("Student").Id));
        }

        public ObservableCollection<Teacher> TeacherList
        {
            get => _teacherService.TeacherList;
            set => _teacherService.TeacherList = value;
        }

        public ObservableCollection<User> UserList
        {
            get => _userService.UserList;
            set => _userService.UserList = value;
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
                    updateCommand = new RelayCommands<Teacher>(_teacherService.Edit, param => selectedTeacher != null);
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
                    deleteCommand = new RelayCommands<Teacher>(_teacherService.Remove, param => selectedTeacher != null);
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
