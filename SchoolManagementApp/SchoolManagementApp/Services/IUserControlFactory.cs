using System.Windows.Controls;

namespace SchoolManagementApp.Services
{
    public interface IUserControlFactory
    {
        T Create<T>() where T : UserControl;
    }
}
