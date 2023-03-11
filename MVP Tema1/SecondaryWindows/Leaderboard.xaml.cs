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
using System.Windows.Shapes;

namespace MVP_Tema1.SecondaryWindows
{
    /// <summary>
    /// Interaction logic for Leaderboard.xaml
    /// </summary>
    public partial class Leaderboard : Window
    {

        private Account currentAccount;

        private List<Account> accounts;

        public Leaderboard(List<Account> accounts, Account currentAccount)
        {
            this.accounts = accounts.OrderByDescending(x => x.Wins).ToList();
            this.currentAccount = currentAccount;
            InitializeComponent();
            LB.ItemsSource = new List<Account> { currentAccount };
        }

        private void PersonalStats_Click(object sender, RoutedEventArgs e)
        {
            LB.ItemsSource = new List<Account> { currentAccount };
        }

        private void GlobalStats_Click(object sender, RoutedEventArgs e)
        {
            LB.ItemsSource = accounts;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ListBox_Scroll(object sender, System.Windows.Controls.Primitives.ScrollEventArgs e)
        {

        }
    }
}
