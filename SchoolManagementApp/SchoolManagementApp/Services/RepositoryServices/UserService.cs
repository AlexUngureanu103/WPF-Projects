using SchoolManagementApp.DataAccess;
using SchoolManagementApp.DataAccess.Models;
using System;
using System.Collections.ObjectModel;

namespace SchoolManagementApp.Services.RepositoryServices
{
    internal class UserService : ICollectionService<User>
    {
        private readonly UnitOfWork unitOfWork;

        public ObservableCollection<User> UserList { get; set; }

        private string errorMessage;

        public UserService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public ObservableCollection<User> GetAll()
        {
            var users = unitOfWork.Users.GetAll();

            return new ObservableCollection<User>(users);
        }

        private bool ValidateUser(User user)
        {
            if (user == null)
            {
                errorMessage = "User cannot be null";
                return false;
            }

            var hasEmailConflicts = unitOfWork.Users.Any(c => c.Email == user.Email);
            if (hasEmailConflicts)
            {
                errorMessage = "Email already exists";
                return false;
            }

            Person person = unitOfWork.Persons.GetById((int)user.personId);
            if (person == null)
            {
                errorMessage = "Invalid personId";
                return false;
            }

            return true;
        }

        public void Add(User user)
        {
            if (!ValidateUser(user)) return;

            unitOfWork.Users.Add(user);
            UserList.Add(user);
            unitOfWork.SaveChanges();
        }

        public void Edit(User user)
        {
            User User = unitOfWork.Users.GetById(user.Id);

            if (user == null)
            {
                errorMessage = "User not found";
                return;
            }

            if (!ValidateUser(user)) return;

            unitOfWork.Users.Update(user);
            unitOfWork.SaveChanges();
        }

        public void Remove(User user)
        {
            if (user == null)
            {
                errorMessage = "User cannot be null";
                return;
            }

            unitOfWork.Users.Remove(user);
            UserList.Remove(user);
            unitOfWork.SaveChanges();
        }
    }
}
