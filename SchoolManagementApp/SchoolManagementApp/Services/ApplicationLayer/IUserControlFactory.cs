using System.Windows.Controls;

namespace SchoolManagementApp.Services.ApplicationLayer
{
    public interface IUserControlFactory
    {
        T Create<T>() where T : UserControl;
    }
}
