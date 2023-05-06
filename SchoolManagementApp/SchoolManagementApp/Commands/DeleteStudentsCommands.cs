﻿using SchoolManagementApp.DataAccess.Abstractions;
using SchoolManagementApp.Services;
using SchoolManagementApp.ViewModels.AdminControls.ManageStudentVMs;
using SchoolManagementApp.ViewModels.AdminControls.ManageUserVMs;
using System;
using System.Windows;

namespace SchoolManagementApp.Commands
{
    internal class DeleteStudentsCommands
    {
        private readonly ManageStudentsVM manageStudentsVM;

        private readonly IStudentRepository studentRepository;

        public DeleteStudentsCommands(ManageStudentsVM manageStudentsVM, IStudentRepository studentRepository)
        {
            this.manageStudentsVM = manageStudentsVM ?? throw new ArgumentNullException(nameof(manageStudentsVM));
            this.studentRepository = studentRepository ?? throw new ArgumentNullException(nameof(studentRepository));
        }

        public void DeleteStudentCommand()
        {
            var result = MessageBox.Show($"Are u sure u want to delete User with Id: {manageStudentsVM.SelectedStudent.Id} ?", "Warning", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {
                studentRepository.Delete(manageStudentsVM.SelectedStudent.Id);
                manageStudentsVM.Students = new System.Collections.ObjectModel.ObservableCollection<DataAccess.Models.Student>(studentRepository.GetAll());
                manageStudentsVM.SelectedStudent = null;
            }
        }

        public void SortEntitiesById()
        {
            if (manageStudentsVM.Students != null && manageStudentsVM.Students.Count > 0)
            {
                manageStudentsVM.Students = SortById.SortEntitiesById(manageStudentsVM.Students);
            }
        }
    }
}
