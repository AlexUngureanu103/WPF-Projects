using SchoolManagementApp.DataAccess.Models;
using System.Collections.ObjectModel;

namespace SchoolManagementApp.Services.RepositoryServices.Abstractions
{
    public interface IUserService : ICollectionService<User>
    {
        ObservableCollection<User> UserList { get; set; }

        ObservableCollection<User> GetAllComplete();

        ObservableCollection<User> GetUsersByRole(int roleId);
    }
}
