using MVP_Tema1.Authentification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MVP_Tema1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            FileLoader avatarIconsFileLoader = new FileLoader(@"Resources\Avatar_icons", @"Avatar_paths");
            FileLoader tokensFileLoader = new FileLoader(@"Resources\Tokens", @"Tokens_paths");

            AccountFileManager accountFileManager = new AccountFileManager(@"Save\Accounts");
            accountFileManager.AddAccount("Test21");
            accountFileManager.AddAccount("test");
            accountFileManager.AddAccount("Mom");
        }

        private void New_User_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Delete_User_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Play_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
