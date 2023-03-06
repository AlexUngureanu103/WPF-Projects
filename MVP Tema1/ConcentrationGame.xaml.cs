using MVP_Tema1.Authentification;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
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
        private BitmapImage cardPath = new BitmapImage(new Uri(Directory.GetFiles(@"Resources\Card", "*.png")[0], UriKind.Relative));

        private KeyValuePair<int, int> BoardDimensions = new KeyValuePair<int, int>(5, 5);
        private List<string> tokens;
        private List<string> tokensToDisplay;

        private Image[] images;

        private int prevImageIndex;
        private Image prevImage;
        private int currentImageIndex;
        private Image currentImage;

        int count;
        int level ;

        private readonly Account account;

        public ConcentrationGame(Account account)
        {
            InitializeComponent();
            this.account = account;
            PlayerName.Content = account.Username;
            LoadPlayerIcon();
            tokens = tokensFileLoader.LoadPaths();
            tokensToDisplay = new List<string>();
            RedimentionateTheGrid();
            NextLevel();
        }

        private void NextLevel()
        {
            level++;

            LevelCounter.Content = $"Current Level {level}";
            ResetLevel();
        }

        private void LoadPlayerIcon()
        {
            PlayerIcon.Source = new BitmapImage(new Uri(account.AvatarPath, UriKind.Relative));
        }

        private void NewGame_Click(object sender, RoutedEventArgs e)
        {
            level = 0;

            NextLevel();
        }

        private void ResetLevel()
        {
            count = 0;
            prevImage = null;
            prevImageIndex = -1;
            currentImage = null;
            currentImageIndex = -1;

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
            OptionSettings optionSettings = new OptionSettings();
            optionSettings.ShowDialog();
            if (!BoardDimensions.Equals(optionSettings.BoardDimensions))
            {
                BoardDimensions = optionSettings.BoardDimensions;
                level = 0;
                NextLevel();
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

            for (int i = 0; i < BoardDimensions.Key; i++)
            {
                for (int j = 0; j < BoardDimensions.Value; j++)
                {
                    int k = i * BoardDimensions.Value + j;
                    images[k] = new Image();
                    images[k].Source = cardPath;
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
            if (CheckBoardFinished())
            {
                NextLevel();
                return;
            }
            Image clickedImage = sender as Image;
            int clickedImageIndex = Grid.GetRow(clickedImage) * BoardDimensions.Value + Grid.GetColumn(clickedImage);

            clickedImage.Source = new BitmapImage(new Uri(tokensToDisplay[clickedImageIndex], UriKind.Relative));
            if (clickedImageIndex == prevImageIndex || clickedImageIndex == currentImageIndex)
            {
                MessageBox.Show("Please choose another image", "Invalid choice");
                return;
            }
            if (prevImageIndex == -1)
            {
                prevImageIndex = clickedImageIndex;
                prevImage = clickedImage;
                //prevImage.Source = new BitmapImage(new Uri(tokensToDisplay[prevImageIndex], UriKind.Relative));
            }
            else if (currentImageIndex == -1)
            {
                currentImageIndex = clickedImageIndex;
                currentImage = clickedImage;
            }
            else
            {
                if (tokensToDisplay[prevImageIndex] == tokensToDisplay[currentImageIndex])
                {
                    Board.Children.Remove(prevImage);
                    Board.Children.Remove(currentImage);
                    count += 2;
                    prevImageIndex = -1;
                    prevImage = null;
                    currentImage = null;
                    currentImageIndex = -1;
                }
                else
                {
                    currentImage.Source = cardPath;
                    currentImageIndex = -1;
                    prevImage.Source = cardPath;
                }
                prevImageIndex = clickedImageIndex;
                prevImage = clickedImage;
            }
        }

        private bool CheckBoardFinished()
        {
            if (tokensToDisplay.Count - count < 3)
            {
                MessageBox.Show($"Congrats , u have finished level {level} out of 3", "Stage Progression");
                return true;
            }
            return false;
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
