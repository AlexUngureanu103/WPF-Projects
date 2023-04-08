using System.Collections.ObjectModel;
using To_Do_List_Management_App.Models;
using To_Do_List_Management_App.ResourceManagement;
using To_Do_List_Management_App.Services;
using To_Do_List_Management_App.Services.Commands;
using To_Do_List_Management_App.Services.SerializeData;

namespace To_Do_List_Management_App.ViewModels
{
    public class StartUpPageVM : BaseVM
    {
        private bool canExecute;
        public bool CanExecute
        {
            get { return canExecute; }
            set
            {
                canExecute = value;
                SaveApplication();
            }
        }

        private ToDoList selectedToDoList;
        public ToDoList SelectedToDoList
        {
            get { return selectedToDoList; }
            set
            {
                selectedToDoList = value;
                ThisStatisticsPanel = UpdateStatisticsPanel.UpdatedStatisticsPanel(categories);
                SaveApplication();
                OnPropertyChanged();
            }
        }

        private Category selectedCategory;
        public Category SelectedCategory
        {
            get { return selectedCategory; }
            set
            {
                selectedCategory = value;
                SaveApplication();
                OnPropertyChanged();
            }
        }

        private TDTask selectedTDTask;
        public TDTask SelectedTDTast
        {
            get { return selectedTDTask; }
            set
            {
                selectedTDTask = value;
                SaveApplication();
                OnPropertyChanged();
            }
        }

        private StartUpPageCommands startUpPageCommands;

        private ManageDataUsage ManageData;

        private ObservableCollection<Category> categories;
        public ObservableCollection<Category> Categories
        {
            get { return categories; }
            set
            {
                categories = value;
                ThisStatisticsPanel = UpdateStatisticsPanel.UpdatedStatisticsPanel(categories);
                SaveApplication();
                OnPropertyChanged();
            }
        }

        private StatisticsPanel thisStatisticsPanel;
        public StatisticsPanel ThisStatisticsPanel
        {
            get { return thisStatisticsPanel; }
            set
            {
                thisStatisticsPanel = value;
                SaveApplication();
                OnPropertyChanged();
            }
        }

        //private ICommand addTaskCommand;
        //public ICommand AddTaskCommand
        //{
        //    get
        //    {
        //        if(addTaskCommand == null)
        //        {
        //            addTaskCommand = new RelayCommand()
        //        }
        //    }
        //}

        public StartUpPageVM()
        {
            ManageData = new ManageDataUsage("Save");
            ReloadApplication();
            startUpPageCommands = new StartUpPageCommands(this);
        }

        private void ReloadApplication()
        {
            var structure = ManageData.LoadData();

            selectedCategory = structure.SelectedCategory;
            selectedToDoList = structure.SelectedToDoList;
            selectedTDTask = structure.SelectedTDTask;
            categories = structure.Categories;
            thisStatisticsPanel = structure.StatisticsPanel;
        }

        private void SaveApplication()
        {
            CurrentStructure currentStructure = new CurrentStructure()
            {
                Categories = this.categories,
                SelectedCategory = this.selectedCategory,
                SelectedTDTask = this.selectedTDTask,
                SelectedToDoList = this.selectedToDoList,
                StatisticsPanel = this.thisStatisticsPanel
            };
            ManageData.SaveData(currentStructure);
        }
    }
}
