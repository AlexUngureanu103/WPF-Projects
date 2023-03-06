using MVP_Tema1.Authentification;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
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

        private Image[] images;

        private Image selectedImage;

        private readonly Account account;

        private KeyValuePair<int, int> BoardDimensions;
        public ConcentrationGame(Account account)
        {
            InitializeComponent();
            this.account = account;
            PlayerName.Content = account.Username;
            LoadPlayerIcon();
            tokens = tokensFileLoader.LoadPaths();
            tokensToDisplay = new List<string>();

            BoardDimensions = new KeyValuePair<int, int>(5, 5);
            RedimentionateTheGrid();
        }

        private void LoadPlayerIcon()
        {
            PlayerIcon.Source = new BitmapImage(new Uri(account.AvatarPath, UriKind.Relative));
        }

        private void NewGame_Click(object sender, RoutedEventArgs e)
        {
            ShuffleTokens();
            GenerateBoard();
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
                GenerateBoard();
            }
            else
            {
                //get new dimensions 
                ShuffleTokens();
                RedimentionateTheGrid();
                GenerateBoard();

            }
        }

        private void RedimentionateTheGrid()
        {
            images = new Image[BoardDimensions.Key * BoardDimensions.Value];

            Board.RowDefinitions.Clear();
            Board.ColumnDefinitions.Clear();
            for (int i = 0; i < BoardDimensions.Key; i++)
            {
                Board.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) });
            }
            for (int i = 0; i < BoardDimensions.Value; i++)
            {
                Board.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
            }
        }

        private void GenerateBoard()
        {
            Board.Children.Clear();
            int tokenCounter = 0;
            Brush maskBrush = new SolidColorBrush(Color.FromArgb(128, 0, 0, 0));

            for (int i = 0; i < BoardDimensions.Key; i++)
            {
                for (int j = 0; j < BoardDimensions.Value; j++)
                {
                    int k = i * BoardDimensions.Value + j;
                    images[k] = new Image();
                    images[k].Source = new BitmapImage(new Uri(tokensToDisplay[tokenCounter], UriKind.Relative));
                    images[k].OpacityMask = maskBrush;
                    images[k].Width = Board.ColumnDefinitions[j].ActualWidth;
                    images[k].Height = Board.RowDefinitions[i].ActualHeight;
                    images[k].MouseLeftButtonDown += Image_MouseLeftButtonDown;
                    Grid.SetRow(images[k], i);
                    Grid.SetColumn(images[k], j);
                    Board.Children.Add(images[k]);
                    tokenCounter++;
                }
            }
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Image clickedImage = sender as Image;

            if (selectedImage == null)
            {
                selectedImage = clickedImage;
            }
            else
            {
                if (selectedImage.Source.ToString() == clickedImage.Source.ToString())
                {
                    Board.Children.Remove(selectedImage);
                    Board.Children.Remove(clickedImage);
                    selectedImage = null;
                }
                else
                {
                    selectedImage = null;
                }
            }
            //if (selectedImage == null)
            //    return;
            //int clickedIndex = Grid.GetRow(selectedImage) * BoardDimensions.Value + Grid.GetColumn(selectedImage);
            //for (int i = 0; i < images.Length; i++)
            //{
            //    if (i == clickedIndex)
            //    {
            //        images[i].Visibility = Visibility.Visible;
            //    }
            //    else
            //    {
            //        images[i].Visibility = Visibility.;
            //    }
            //}
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
