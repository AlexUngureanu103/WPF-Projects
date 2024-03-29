﻿using System.Collections.Generic;
using System.Windows;

namespace MVP_Tema1
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        private bool success;
        public bool registerSuccesful
        {
            get
            {
                bool auxiliar = success;
                success = false;
                return auxiliar;
            }
            private set { success = value; }
        }
        public string username { get; private set; }

        private readonly List<string> accounts;

        //public string password{ get; private set; }

        public RegisterWindow(List<string> accounts)
        {
            InitializeComponent();
            this.accounts = accounts;
            username = string.Empty;
            success = false;
            //password = string.Empty;
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            username = usernameBox.Text;
            //password = passwordBox.Text;
            if (username == "" || System.Text.RegularExpressions.Regex.IsMatch(username, @"[^a-zA-Z0-9]"))
            {
                success = false;
                MessageBox.Show("Please enter a valid username!");
            }
            else if (accounts.Contains(username))
            {
                success = false;
                MessageBox.Show("Username already exists!");
            }
            else
            {
                success = true;
                this.Close();
            }
        }

        private void RegisterBackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
