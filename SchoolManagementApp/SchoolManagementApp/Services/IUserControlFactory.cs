using System.Windows.Controls;

namespace SchoolManagementApp.Services
{
    internal interface IUserControlFactory
    {
        T Create<T>() where T : UserControl;
    }
}
