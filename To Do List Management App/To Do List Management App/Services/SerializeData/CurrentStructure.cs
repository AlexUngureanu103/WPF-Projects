using System.Collections.ObjectModel;
using To_Do_List_Management_App.Models;

namespace To_Do_List_Management_App.Services.SerializeData
{
    public class CurrentStructure
    {
        public Category SelectedCategory { get; set; }

        public ToDoList SelectedToDoList { get; set; }

        public TDTask SelectedTDTask { get; set; }

        public ObservableCollection<Category> Categories { get; set; }

        public StatisticsPanel StatisticsPanel { get; set; }
    }
}
