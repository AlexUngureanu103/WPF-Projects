﻿using SchoolManagementApp.Commands;
using SchoolManagementApp.DataAccess;
using SchoolManagementApp.DataAccess.Models;
using SchoolManagementApp.Services.RepositoryServices;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using To_Do_List_Management_App.ViewModels;

namespace SchoolManagementApp.ViewModels.AdminControls
{
    internal class ManageCoursesVM : BaseVM
    {
        private readonly SchoolManagementDbContext _dbContext;

        private readonly CourseService courseService;

        public ManageCoursesVM(SchoolManagementDbContext dbContext)
        {
            this._dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            courseService = new CourseService(new UnitOfWork(dbContext));
            CourseList = courseService.GetAll();
        }

        public ObservableCollection<CourseType> CourseList
        {
            get => courseService.CourseList;
            set => courseService.CourseList = value;
        }

        private CourseType selectedCourse;
        public CourseType SelectedCourse
        {
            get { return selectedCourse; }
            set
            {
                selectedCourse = value;
                OnPropertyChanged(nameof(SelectedCourse));
            }
        }

        private ICommand addCommand;
        public ICommand AddCommand
        {
            get
            {
                if (addCommand == null)
                {
                    addCommand = new RelayCommands<CourseType>(courseService.Add , param => selectedCourse == null);
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
                    updateCommand = new RelayCommands<CourseType>(courseService.Edit, param => selectedCourse != null);
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
                    deleteCommand = new RelayCommands<CourseType>(courseService.Remove, param => selectedCourse != null);
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
                    clearCommand = new RelayCommand(Clear, param => selectedCourse != null);
                }
                return clearCommand;
            }
        }

        private void Clear()
        {
            SelectedCourse = null;
        }
    }
}