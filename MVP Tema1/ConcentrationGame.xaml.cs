using MVP_Tema1.Authentification;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media.Imaging;

namespace MVP_Tema1
{
    /// <summary>
    /// Interaction logic for ConcentrationGame.xaml
    /// </summary>
    public partial class ConcentrationGame : Window
    {
        private FileLoader tokensFileLoader = new FileLoader(@"Resources\Tokens", @"Tokens_paths");

        private List<string> tokens;

        private List<string> tokensToDisplay;

        private readonly Account account;

        private KeyValuePair<int, int> BoardDimensions;
        public ConcentrationGame(Account account)
        {
            InitializeComponent();
            this.account = account;
            PlayerName.Content = account.Username;
            BoardDimensions = new KeyValuePair<int, int>(5, 5);
            LoadPlayerIcon();
            tokens = tokensFileLoader.LoadPaths();
            tokensToDisplay = new List<string>();
            ShuffleTokens();
        }

        private void LoadPlayerIcon()
        {
            PlayerIcon.Source = new BitmapImage(new Uri(account.AvatarPath, UriKind.Relative));
        }

        private void NewGame_Click(object sender, RoutedEventArgs e)
        {
            ShuffleTokens();
        }

        private void SaveGame_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LoadGame_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Help_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Press the Images to reveal the image behind and find the pairs to win\n", "Info");
        }

        private void Options_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Standard 5x5 size ?", "Chooe board size", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                BoardDimensions = new KeyValuePair<int, int>(5, 5);
                RedimentionateTheGrid();
            }
            else
            {
                //get new dimensions 

                RedimentionateTheGrid();
                ShuffleTokens();
            }
        }

        private void RedimentionateTheGrid()
        {
            //TD
        }

        private void About_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Nume: Ungureanu Alexandru\nGrupa: 10LF213\nSpecializare: Informatica", "About");
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            // return to login page 
        }

        private void ShuffleTokens()
        {
            int tokenCounter = 0;
            tokensToDisplay = new List<string>();
            Random randomGenerator = new Random();
            while (tokenCounter < BoardDimensions.Value * BoardDimensions.Key)
            {
                int randomIndex = randomGenerator.Next(tokens.Count);
                if (!tokensToDisplay.Contains(tokens[randomIndex]))
                {
                    tokenCounter++;
                    AddInRandomOrder(randomIndex);
                    if (tokenCounter < BoardDimensions.Key * BoardDimensions.Value)
                    {
                        tokenCounter++;
                        AddInRandomOrder(randomIndex);
                    }
                }
            }
        }

        private void AddInRandomOrder(int index)
        {
            Random random = new Random();
            int randomIndex = random.Next(tokensToDisplay.Count);
            tokensToDisplay.Insert(randomIndex, tokens[index]);
        }
    }
}
