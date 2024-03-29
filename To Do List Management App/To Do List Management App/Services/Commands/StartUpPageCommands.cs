﻿using System;
using System.Windows;
using To_Do_List_Management_App.Services.SerializeData;
using To_Do_List_Management_App.ViewModels;

namespace To_Do_List_Management_App.Services.Commands
{
    public class StartUpPageCommands
    {
        private StartUpPageVM startUpPageVM;

        public readonly ArchiveData archiveData;
        public StartUpPageCommands(StartUpPageVM startUpPageVM)
        {
            this.startUpPageVM = startUpPageVM ?? throw new ArgumentNullException(nameof(startUpPageVM));
            archiveData = new ArchiveData(startUpPageVM, "Archive");
        }

        public void DeleteToDoList()
        {
            if (!ConfirmAction())
            {
                return;
            }
            var parentTDL = GetParentOrRootTDL.GetParentOfSelectedTDL(startUpPageVM.RootToDoList, startUpPageVM.SelectedToDoList);
            if (parentTDL != startUpPageVM.SelectedToDoList)
            {
                parentTDL.toDoLists.Remove(startUpPageVM.SelectedToDoList);
            }
            else
            {
                startUpPageVM.RootToDoList.Remove(startUpPageVM.SelectedToDoList);
            }
            startUpPageVM.SelectedToDoList = null;
            startUpPageVM.SelectedTDTask = null;
        }

        private bool ConfirmAction()
        {
            var result = MessageBox.Show("Are you sure you want to perform this action?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.No)
                return false;
            return true;
        }

        public void DeleteTask()
        {
            if (!ConfirmAction())
            {
                return;
            }

            startUpPageVM.SelectedToDoList.Tasks.Remove(startUpPageVM.SelectedTDTask);
            startUpPageVM.SelectedTDTask = null;
        }

        public void MoveTaskUp()
        {
            int index = startUpPageVM.SelectedToDoList.Tasks.IndexOf(startUpPageVM.SelectedTDTask);
            if (index > 0)
            {
                startUpPageVM.SelectedToDoList.Tasks.Move(index, index - 1);
            }
        }

        public void MoveTaskDown()
        {
            int index = startUpPageVM.SelectedToDoList.Tasks.IndexOf(startUpPageVM.SelectedTDTask);
            if (index < startUpPageVM.SelectedToDoList.Tasks.Count - 1)
            {
                startUpPageVM.SelectedToDoList.Tasks.Move(index, index + 1);
            }
        }

        public void DisplayAbout()
        {
            MessageBox.Show("Nume: Ungureanu Alexandru\nGrupa: 10LF213\nSpecializare: Informatica", "About");
        }

        public void ArchiveCurrentData()
        {
            archiveData.ArchiveSavedData();
        }

        public void LoadArchivedData()
        {      
            LoadData(archiveData.LoadLastArchive());
        }

        public void LoadDb(string database)
        {
            LoadData(archiveData.LoadArchive(database));
        }
        
        private void LoadData(CurrentStructure structure)
        {
            startUpPageVM.AvailableCategories = structure.Categories;
            startUpPageVM.RootToDoList = structure.TDL;
            startUpPageVM.ThisStatisticsPanel = structure.StatisticsPanel;
            startUpPageVM.SelectedTDTask = null;
            startUpPageVM.SelectedToDoList = null;
        }
    }
}
