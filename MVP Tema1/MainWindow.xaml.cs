using MVP_Tema1.Authentification;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace MVP_Tema1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private FileLoader avatarIconsFileLoader = new FileLoader(@"Resources\Avatar_icons", @"Avatar_paths");

        private FileLoader tokensFileLoader = new FileLoader(@"Resources\Tokens", @"Tokens_paths");

        private List<string> icons;

        private AccountFileManager accountFileManager = new AccountFileManager(@"Save\Accounts");

        public string ImagePath { get; set; }

        private int currentIconIndex = 0;

        // to import it from the account file manager

        public MainWindow()
        {
            InitializeComponent();
            accountFileManager.AddAccount(new Account("user1", @"Resources\Avatar_icons\surprised_rabbit.png"));
            accountFileManager.AddAccount(new Account("user2", @"Resources\Avatar_icons\smiley_face.png"));
            ImagePath = @"Resources\Avatar_icons\wink_emoji.png";
            icons = avatarIconsFileLoader.LoadPaths();
            currentIconIndex = icons.IndexOf(ImagePath);
            UpdateImagePath();
        }

        private void NewUser_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow registerWindow = new RegisterWindow(accountFileManager.GetRegisteredAccounts());
            registerWindow.ShowDialog();
            if (registerWindow.registerSuccesful == true)
            {
                string username = registerWindow.username;
                //string password = registerWindow.password;
                Account account = new Account(username, /*password,*/ ImagePath);
                accountFileManager.AddAccount(account);
            }
        }

        private void DeleteUser_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Play_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void PrevIcon_Click(object sender, RoutedEventArgs e)
        {
            currentIconIndex = (currentIconIndex - 1 + icons.Count) % icons.Count;
            UpdateImagePath();
        }

        private void NextIcon_Click(object sender, RoutedEventArgs e)
        {
            currentIconIndex = (currentIconIndex + 1) % icons.Count;
            UpdateImagePath();
        }

        private void UpdateImagePath()
        {
            ImagePath = icons[currentIconIndex];
            Icon.Source = new BitmapImage(new Uri(ImagePath, UriKind.Relative));
        }
    }
}
