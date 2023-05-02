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
    /// Interaction logic for SaveGameDataWindow.xaml
    /// </summary>
    public partial class SaveGameDataWindow : Window
    {

        public string NameOFTheSave { get; set; }

        public SaveGameDataWindow()
        {
            InitializeComponent();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(SaveName.Text, @"[^a-zA-Z0-9]"))
            {
                MessageBox.Show("Invalid caracters provided!", "Error");
                SaveName.Text = string.Empty;
                return;
            }
            NameOFTheSave = SaveName.Text;
            this.Close();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NameOFTheSave = string.Empty;
            this.Close();
        }
    }
}
