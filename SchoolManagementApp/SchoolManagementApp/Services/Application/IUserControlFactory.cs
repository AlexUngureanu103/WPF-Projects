using System.Windows.Controls;

namespace SchoolManagementApp.Services.Application
{
    public interface IUserControlFactory
    {
        T Create<T>() where T : UserControl;
    }
}
