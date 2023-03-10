using MVP_Tema1.Authentification;
using MVP_Tema1.SaveData;
using MVP_Tema1.SecondaryWindows;
using System;
using System.Collections.Generic;
using System.IO;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
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
        int level;

        private readonly Account account;

        private SaveConfig saveConfig;

        private Timer timer;
        private float timeLeft;

        public ConcentrationGame(Account account)
        {
            InitializeComponent();
            this.account = account;
            saveConfig = new SaveConfig(@"Save", account);
            PlayerName.Content = account.Username;
            LoadPlayerIcon();
            tokens = tokensFileLoader.LoadPaths();
            tokensToDisplay = new List<string>();

            timer = new Timer();
            timer.Interval = 100;
            timer.Elapsed += Timer_Tick;
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
            timeLeft = BoardDimensions.Value * BoardDimensions.Key * 2;

            timer.Start();

            ShuffleTokens();
            GenerateBoard();
        }

        private void Timer_Tick(object sender, ElapsedEventArgs e)
        {
            if (!this.IsVisible)
            {
                timer.Stop();
            }
            timeLeft -= 0.1f;
            Application.Current.Dispatcher.Invoke(() => TimerCountDown.Content = $"Time left: {timeLeft.ToString("0.0")}s");
            //TimerCountDown.Content = $"Time left: {timeLeft}s";
            if (timeLeft <= 0)
            {
                timer.Stop();
                MessageBox.Show("You lost the game", "Info");
                level = 0;
                Application.Current.Dispatcher.Invoke(() => NextLevel());
            }
        }

        private void SaveGame_Click(object sender, RoutedEventArgs e)
        {
            SaveGameDataWindow saveGameDataWindow = new SaveGameDataWindow();
            timer.Stop();
            saveGameDataWindow.ShowDialog();
            timer.Start();
            if (saveGameDataWindow.NameOFTheSave != string.Empty)
                saveConfig.SaveDataToFile(Board, tokensToDisplay, count, level, saveGameDataWindow.NameOFTheSave);
        }

        private void LoadGame_Click(object sender, RoutedEventArgs e)
        {
            ManageLoadData();
        }

        private void ManageLoadData()
        {
            ChooseSavedFile chooseSavedFile = new ChooseSavedFile(saveConfig.GetSavedGames());
            timer.Stop();
            chooseSavedFile.ShowDialog();
            timer.Start();
            if (chooseSavedFile.selectedGamePath != null)
            {
                if (chooseSavedFile.toDelete == true)
                {
                    saveConfig.DeleteFile(chooseSavedFile.selectedGamePath);
                    ManageLoadData();
                    return;
                }
                var gameData = saveConfig.LoadDataFromFile(chooseSavedFile.selectedGamePath);
                LoadGridData(gameData);
                MessageBox.Show("Game loaded successfully, But The has been DELETED", "Info");
            }
        }

        private void LoadGridData(GridData gameData)
        {
            BoardDimensions = new KeyValuePair<int, int>(gameData.rows, gameData.columns);
            Board.Children.Clear();
            RedimentionateTheGrid();
            count = gameData.count;
            level = gameData.level;
            tokensToDisplay = gameData.ImagesPath;
            LevelCounter.Content = $"Curent level{level}";

            for (int i = 0; i < gameData.ImagesRow.Count; i++)
            {
                images[i] = new Image();
                images[i].Source = cardPath;
                images[i].MouseLeftButtonDown += Image_MouseLeftButtonDown;
                Grid.SetRow(images[i], gameData.ImagesRow[i]);
                Grid.SetColumn(images[i], gameData.ImagesColumn[i]);
                Board.Children.Add(images[i]);
            }
        }

        private void Help_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Press the Images to reveal the image behind and find the pairs to win\n", "Info");
        }

        private void Options_Click(object sender, RoutedEventArgs e)
        {
            OptionSettings optionSettings = new OptionSettings();
            timer.Stop();
            optionSettings.ShowDialog();
            timer.Start();
            if (!BoardDimensions.Equals(optionSettings.BoardDimensions))
            {
                BoardDimensions = optionSettings.BoardDimensions;
                level = 0;
                RedimentionateTheGrid();
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

            for (int i = 0; i < BoardDimensions.Key; i++)
            {
                for (int j = 0; j < BoardDimensions.Value; j++)
                {
                    int k = i * BoardDimensions.Value + j;
                    images[k] = new Image();
                    images[k].Source = cardPath;
                    images[k].MouseLeftButtonDown += Image_MouseLeftButtonDown;
                    Grid.SetRow(images[k], i);
                    Grid.SetColumn(images[k], j);
                    Board.Children.Add(images[k]);
                }
            }
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (CheckBoardFinished())
            {
                CheckIfGameEnded();
                NextLevel();
                return;
            }
            Image clickedImage = sender as Image;
            int clickedImageIndex = Grid.GetRow(clickedImage) * BoardDimensions.Value + Grid.GetColumn(clickedImage);

            clickedImage.Source = new BitmapImage(new Uri(tokensToDisplay[clickedImageIndex], UriKind.RelativeOrAbsolute));
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

        private void CheckIfGameEnded()
        {
            if (level == 3)
            {
                timer.Stop();
                MessageBox.Show("Congratulations , You have won a game!", "Congratulations");
                account.Wins++;
                this.Close();
            }
        }

        private bool CheckBoardFinished()
        {
            if (tokensToDisplay.Count - count < 3)
            {
                timer.Stop();
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
            timer.Stop();
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

        private void Statistics_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}
