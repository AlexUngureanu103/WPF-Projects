using SchoolManagementApp.Domain.Models;
using System.Collections.ObjectModel;

namespace SchoolManagementApp.Domain.ServiceAbstractions
{
    public interface IUserService : ICollectionService<User>
    {
        ObservableCollection<User> UserList { get; set; }

        string errorMessage { get; }

        ObservableCollection<User> GetAllComplete();

        ObservableCollection<User> GetUsersByRole(int roleId);
    }
}
