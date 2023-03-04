using MVP_Tema1.Authentification;
using System.Windows;

namespace MVP_Tema1
{
    /// <summary>
    /// Interaction logic for ConcentrationGame.xaml
    /// </summary>
    public partial class ConcentrationGame : Window
    {
        private readonly Account account;
        public ConcentrationGame(Account account)
        {
            InitializeComponent();
            this.account = account;
        }

    }
}
