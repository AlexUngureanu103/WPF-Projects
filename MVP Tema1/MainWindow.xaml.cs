﻿using MVP_Tema1.Authentification;
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

        private Account currentAccount;

        // to import it from the account file manager

        public MainWindow()
        {
            InitializeComponent();
            UpdateUserList();
            ImagePath = @"Resources\Avatar_icons\wink_emoji.png";
            icons = avatarIconsFileLoader.LoadPaths();
            currentIconIndex = icons.IndexOf(ImagePath);
            UpdateImagePath();
        }

        private void Users_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Users.SelectedItem == null)
            {
                currentAccount = null;
                return;
            }
            currentAccount = accountFileManager.GetAccount(Users.SelectedItem.ToString());
            currentIconIndex = icons.IndexOf(currentAccount.AvatarPath);
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
                UpdateUserList();
            }
        }

        private void UpdateUserList()
        {
            Users.ItemsSource = accountFileManager.GetRegisteredAccounts();
        }

        private void DeleteUser_Click(object sender, RoutedEventArgs e)
        {
            if (currentAccount == null)
            {
                MessageBox.Show("Please select an account");
                return;
            }
            accountFileManager.RemoveAccount(currentAccount);
            Users.SelectedItem = null;
            UpdateUserList();
        }

        private void Play_Click(object sender, RoutedEventArgs e)
        {
            if (currentAccount == null)
            {
                MessageBox.Show("Please select an account");
                return;
            }
            MessageBox.Show("Play");
            //close or hide the main window
            //open the game window
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
            if (currentAccount != null)
            {
                UpdatePlayerProfile();
            }
            Icon.Source = new BitmapImage(new Uri(ImagePath, UriKind.Relative));
        }

        private void UpdatePlayerProfile()
        {
            currentAccount.AvatarPath = ImagePath;
            accountFileManager.UpdateAccount(currentAccount);
        }

        private void Users_Scroll(object sender, System.Windows.Controls.Primitives.ScrollEventArgs e)
        {

        }
    }
}
