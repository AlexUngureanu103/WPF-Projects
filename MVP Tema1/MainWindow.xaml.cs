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

        // to import it from the account file manager

        public MainWindow()
        {
            InitializeComponent();
            ImagePath = @"Resources\Avatar_icons\wink_emoji.png";
            icons = avatarIconsFileLoader.LoadPaths();
            currentIconIndex = icons.IndexOf(ImagePath);
            UpdateImagePath();
        }

        private void NewUser_Click(object sender, RoutedEventArgs e)
        {

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
            currentIconIndex = (currentIconIndex - 1) % icons.Count;
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
            //BitmapImage newImageSource = new BitmapImage();
            //newImageSource.BeginInit();
            //newImageSource.UriSource = new Uri(@"Resources\Avatar_icons\wink_emoji.png");
            //newImageSource.EndInit();
            Icon.Source = new BitmapImage(new Uri(ImagePath,UriKind.Relative));
        }
    }
}
