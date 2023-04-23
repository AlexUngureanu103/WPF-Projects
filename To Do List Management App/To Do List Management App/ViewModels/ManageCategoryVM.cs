using System.Collections.ObjectModel;
using System.Windows.Input;
using To_Do_List_Management_App.Commands;
using To_Do_List_Management_App.Services.Commands;
using To_Do_List_Management_App.Services.Validators;

namespace To_Do_List_Management_App.ViewModels
{
    internal class ManageCategoryVM : BaseVM
    {
        private ManageCategoriesCommands manageCategoriesCommands;

        private ObservableCollection<string> availableCategories;
        public ObservableCollection<string> AvailableCategories
        {
            get
            { return availableCategories; }
            set
            {
                availableCategories = value;
                OnPropertyChanged();
            }
        }

        private string selectedCategory;
        public string SelectedCategory
        {
            get { return selectedCategory; }
            set
            {
                selectedCategory = value;
                OnPropertyChanged();
            }
        }

        private string categoryToAdd;
        public string CategoryToAdd
        {
            get { return categoryToAdd; }
            set
            {
                categoryToAdd = value;
                OnPropertyChanged();
                CanAddCategory = ManagaCategoryValidators.IsCategoryNameValid(categoryToAdd,availableCategories);
            }
        }

        private bool canAddCategory;
        public bool CanAddCategory
        {
            get
            {
                return canAddCategory;
            }
            set
            {
                canAddCategory = value;
            }
        }

        private ICommand addCategoryCommand;
        public ICommand AddCategoryCommand
        {
            get
            {
                if(addCategoryCommand == null)
                {
                    addCategoryCommand = new RelayCommand(manageCategoriesCommands.AddCategory, param => canAddCategory);
                }
                return addCategoryCommand;
            }
        }

        private ICommand deleteCategoryCommand;
        public ICommand DeleteCategoryCommand
        {
            get
            {
                if (deleteCategoryCommand == null)
                {
                    deleteCategoryCommand = new RelayCommand(manageCategoriesCommands.DeleteCategory, param => selectedCategory != null);
                }
                return deleteCategoryCommand;
            }
        }

        public ManageCategoryVM(StartUpPageVM startUpPageVM)
        {
            if (startUpPageVM.AvailableCategories == null)
            {
                startUpPageVM.AvailableCategories = new ObservableCollection<string>();
            }
            manageCategoriesCommands = new ManageCategoriesCommands(this);
            this.AvailableCategories = startUpPageVM.AvailableCategories;
            this.StartUpPageVM = startUpPageVM;
        }

        public StartUpPageVM StartUpPageVM;
    }
}
