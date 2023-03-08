using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace MVP_Tema1
{
    /// <summary>
    /// Interaction logic for ChooseSavedFile.xaml
    /// </summary>
    public partial class ChooseSavedFile : Window
    {
        private List<string> SavedGames;

        public bool toDelete;

        public string selectedGamePath { get; private set; }

        public ChooseSavedFile(List<string> savedGames)
        {
            InitializeComponent();
            toDelete = false;
            SavedGamesList.ItemsSource = savedGames;
            SavedGames = savedGames;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            selectedGamePath = null;
            this.Close();
        }

        private void Load_Click(object sender, RoutedEventArgs e)
        {
            toDelete = false;
            this.Close();
        }

        private void SavedGames_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedGamePath = SavedGamesList.SelectedItem.ToString();
        }

        private void SavedGamesList_Scroll(object sender, System.Windows.Controls.Primitives.ScrollEventArgs e)
        {

        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            toDelete = true;
            if (selectedGamePath == null)
            {
                MessageBox.Show("Please chose a valid save file", "Error");
                return;
            }
            this.Close();
        }
    }
}
