using System.Collections.Generic;
using System.Windows;

namespace MVP_Tema1
{
    /// <summary>
    /// Interaction logic for Options.xaml
    /// </summary>
    public partial class OptionSettings : Window
    {
        public KeyValuePair<int, int> BoardDimensions { get; set; }
        public OptionSettings()
        {
            InitializeComponent();
            BoardDimensions = new KeyValuePair<int, int>(5, 5);
        }

        private void ClassicDimension_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void CustomDimensions_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(NoRows.Text, out int width) || !int.TryParse(NoColumns.Text, out int height))
            {
                MessageBox.Show("Invalid dimensions");
                return;
            }
            if (width < 2 || height < 2)
            {
                MessageBox.Show("Dimensions must be at least 2x2");
                return;
            }
            if (width > 10 || height > 10)
            {
                MessageBox.Show("Dimensions must be at most 10x10");
                return;
            }
            BoardDimensions = new KeyValuePair<int, int>(width, height);
            this.Close();
        }
    }
}
